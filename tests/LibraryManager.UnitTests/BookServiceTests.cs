using AutoFixture;
using Azure.Core;
using FluentAssertions;
using LibraryManager.Application.Dtos.Books;
using LibraryManager.Application.Extensions;
using LibraryManager.Application.Interfaces;
using LibraryManager.Application.Services;
using LibraryManager.Application.Specyfication;
using LibraryManager.Domain.Common;
using LibraryManager.Domain.Contracts;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enum;
using LibraryManager.Infrastructure.Repositories;
using Moq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace LibraryManager.UnitTests
{
    public class BookServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        private readonly Fixture _fixture;

        private readonly BookService _sut;

        public BookServiceTests()
        {
            
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _fixture = new Fixture();

            _sut = new BookService(_unitOfWorkMock.Object);
        }

        #region CreateBookAsync
        [Fact]
        public async Task CreateBookAsync_ShouldReturnSuccessWithCreateBookResponse_WhenDataIsValid()
        {
            //Arrange
            var request = _fixture.Create<CreateBookRequest>();
            var expected = request.ToBook();
            _unitOfWorkMock.Setup(tmp => tmp.Book.AddAsync(It.IsAny<Book>()));

            //act
            var result = await _sut.CreateBookAsync(request);

            //assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Id.Should().NotBeEmpty();
            _unitOfWorkMock.Verify(tmp => tmp.Book.AddAsync(
                It.Is<Book>(book => 
                    book.Title == request.Title &&
                    book.Isbn == request.Isbn &&
                    book.AuthorId == request.AuthorId &&
                    book.CategoryId == request.CategoryId))
                ,Times.Once);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateBookAsync_ShouldThrowArgumentNullException_WhenRequestIsNull()
        {
            //arragne
            CreateBookRequest? request = null;
            
            //act
            Func<Task<Result<CreateBookResponse>>> act =
                async () => await _sut.CreateBookAsync(request!);

            //assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task CreateBookAsync_ShouldReturnFailure_WhenPublishDateIsInFuture()
        {
            //arrange
            var request = _fixture.Build<CreateBookRequest>()
                .With(book => book.PublishDate, DateTime.UtcNow.AddDays(1))
                .Create();

            //act
            var result = await _sut.CreateBookAsync(request);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
            _unitOfWorkMock.Verify(
                tmp => tmp.Book.AddAsync(It.IsAny<Book>()), Times.Never);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }

        [Fact]
        public async Task CreateBookAsync_ShouldReturFailure_WhenIsbnAlreadyExists()
        {
            //arrange
            var request = _fixture.Create<CreateBookRequest>();

            _unitOfWorkMock.Setup(
                x => x.Book.CheckIsbnExistsAsync(request.Isbn))
                .ReturnsAsync(false);

            //act
            var result = await _sut.CreateBookAsync(request);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
            _unitOfWorkMock.Verify(
                x => x.Book.CheckIsbnExistsAsync(It.IsAny<string>()), Times.Once);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }
        [Fact]
        public async Task CreateBookAsync_ShouldReturnFailure_WhenAuthorIdDoesNotExists()
        {
            //arrange
            var request = _fixture.Create<CreateBookRequest>();
            _unitOfWorkMock
                .Setup(x => x.Author.FindByIdAsync(request.AuthorId))
                .ReturnsAsync((Author)null!);

            //act
            var result = await _sut.CreateBookAsync(request);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();

            _unitOfWorkMock.Verify(
                x => x.Author.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }
        [Fact]
        public async Task CreateBookAsync_ShouldReturnFailure_WhenCategoryIdDoesNotExists()
        {
            //arange
            var request = _fixture.Create<CreateBookRequest>();
            _unitOfWorkMock.Setup(
                x => x.Category.FindByIdAsync(request.CategoryId))
                .ReturnsAsync((Category)null!);

            //act
            var result = await _sut.CreateBookAsync(request);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
                _unitOfWorkMock.Verify(
                    x => x.Category.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }
        #endregion

        #region GetBookByIdAsync

        [Fact]
        public async Task GetBookByIdAsync_ShouldReturnSuccessResultWithData_WhenIdIsValid()
        {
            //arrange
            Guid id = Guid.CreateVersion7();
            var existingBook = _fixture.Build<Book>()
                .With(x => x.Id, id)
                .Create();

            _unitOfWorkMock.Setup(
                x => x.Book.FindByIdAsync(id))
                .ReturnsAsync(existingBook);

            //act
            var result = await _sut.GetBookByIdAsync(id);

            //assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Id.Should().Be(id);
            _unitOfWorkMock.Verify(
                x => x.Book.FindByIdAsync(It.IsAny<Guid>()), Times.Once);

        }
        [Fact]
        public async Task GetBookByIdAsync_ShouldReturnFailureResult_WhenIdIsInvalid()
        {
            //arrange
            _unitOfWorkMock.Setup(
                x => x.Book.FindByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Book)null!);

            //act
            var result = await _sut.GetBookByIdAsync(It.IsAny<Guid>());

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
            _unitOfWorkMock.Verify(
                x => x.Book.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
        }

        #endregion

        #region UpdateBookAsync

        [Fact]
        public async Task UpdateBookAsync_ShouldReturnSuccessWithData_WhenRequestDataIsValid()
        {
            //act
            Guid id = Guid.CreateVersion7();
            var request = _fixture.Create<UpdateBookRequest>();
            var book = request.ToBook();
            book.Id = id;
            var excepted = book.ToUpdateResponse();

            var existingBook = _fixture.Create<Book>();

            _unitOfWorkMock.Setup(
                x => x.Book.FindByIdAsync(id))
                .ReturnsAsync(existingBook);

            _unitOfWorkMock.Setup(
                x => x.Book.UpdateAsync(book));

            //act 
            var result = await _sut.UpdateBookAsync(id,request);

            //assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(excepted);

            _unitOfWorkMock.Verify(
                x => x.Book.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
            _unitOfWorkMock.Verify(
                x => x.Book.UpdateAsync(It.IsAny<Book>()), Times.Once);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Once);

        }

        [Fact]
        public async Task UpdateBookAsync_ShouldReturnFailure_WhenIdIsInvalid()
        {
            //act
            Guid id = Guid.CreateVersion7();
            var request = _fixture.Create<UpdateBookRequest>();

            _unitOfWorkMock.Setup(
                x => x.Book.FindByIdAsync(id))
                .ReturnsAsync((Book)null!);

            //act 
            var result = await _sut.UpdateBookAsync(id, request);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
            _unitOfWorkMock.Verify(
                x => x.Book.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }
        [Fact]
        public async Task UpdateBookAsync_ShouldThrowNullException_WhenUpdateRequestIsNull()
        {
            //act
            Guid id = Guid.CreateVersion7();
            UpdateBookRequest request = null!;

            //act 
            Func<Task<Result<UpdateBookResponse>>> result = 
                async () => await _sut.UpdateBookAsync(id, request);

            //assert
            await result.Should().ThrowAsync<ArgumentNullException>();
            _unitOfWorkMock.Verify(x => x.Book.UpdateAsync(It.IsAny<Book>()), Times.Never);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }
        [Fact]
        public async Task UpdateBookAsync_ShouldReturnFailure_WhenNewIsbnAlreadyExists()
        {
            //arrange
            Guid id = Guid.CreateVersion7();
            var request = _fixture.Create<UpdateBookRequest>();

            var existingBook = _fixture
                .Create<Book>();

            _unitOfWorkMock.Setup(
                x => x.Book.FindByIdAsync(id))
                .ReturnsAsync(existingBook);
            _unitOfWorkMock.Setup(
                x => x.Book.CheckIsbnExistsAsync(request.Isbn))
                .ReturnsAsync(true);

            //act 
            var result = await _sut.UpdateBookAsync(id, request);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
            _unitOfWorkMock.Verify(
                x => x.Book.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
            _unitOfWorkMock.Verify(
                x => x.Book.CheckIsbnExistsAsync(It.IsAny<string>()), Times.Once);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }
        [Fact]
        public async Task UpdateBookAsync_ShouldReturnFailure_WhenNewAuthorIdDoesNotExists()
        {
            //arrange
            Guid id = Guid.CreateVersion7();
            var request = _fixture.Create<UpdateBookRequest>();
            var existingBook = _fixture
                .Create<Book>();


            _unitOfWorkMock.Setup(
                x => x.Book.FindByIdAsync(id))
                .ReturnsAsync(existingBook);

            _unitOfWorkMock.Setup(
                x => x.Author.FindByIdAsync(request.AuthorId))
                .ReturnsAsync((Author)null!);

            //act 
            var result = await _sut.UpdateBookAsync(id, request);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
            _unitOfWorkMock.Verify(
                x => x.Book.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.Author.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }
        [Fact]
        public async Task UpdateBookAsync_ShouldReturnFailure_WhenNewCategoryIdDoesNotExits()
        {
            //arrange
            Guid id = Guid.CreateVersion7();
            var request = _fixture.Create<UpdateBookRequest>();
            var existingBook = _fixture
                .Create<Book>();

            _unitOfWorkMock.Setup(
                x => x.Book.FindByIdAsync(id))
                .ReturnsAsync(existingBook);

            _unitOfWorkMock.Setup(
                x => x.Category.FindByIdAsync(request.CategoryId))
                .ReturnsAsync((Category)null!);

            //act 
            var result = await _sut.UpdateBookAsync(id, request);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();

            _unitOfWorkMock.Verify(
                x => x.Book.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
            _unitOfWorkMock.Verify(
                x => x.Category.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }
        [Fact]
        public async Task UpdateBookAsync_ShouldReturnFailure_WhenBookStatusIsBorrowed()
        {
            //arrange
            Guid id = Guid.CreateVersion7();
            var request = _fixture.Build<UpdateBookRequest>()
                .With(x => x.Status, BookStatus.Borrowed)
                .Create();

            //act
            var result = await _sut.UpdateBookAsync(id, request);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
            _unitOfWorkMock.Verify(
                x => x.Book.UpdateAsync(It.IsAny<Book>()), Times.Never);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }

        #endregion

        #region DeleteBookAsync

        [Fact]
        public async Task DeleteBookAsync_ShouldReturnSucces_WhenObjectIsDeleted()
        {
            //arrange
            Guid id = Guid.CreateVersion7();
            var existingBook = _fixture.Create<Book>();
            _unitOfWorkMock.Setup(
                x => x.Book.FindByIdAsync(id))
                .ReturnsAsync(existingBook);
            _unitOfWorkMock.Setup(
                x => x.Book.DeleteAsync(existingBook));

            //act
            var result = await _sut.DeleteBookAsync(id);

            //assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeTrue();
            _unitOfWorkMock.Verify(
                x => x.Book.DeleteAsync(It.IsAny<Book>()),Times.Once);
            _unitOfWorkMock.Verify(
                x => x.Book.FindByIdAsync(It.IsAny<Guid>()),Times.Once);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Once);
        }
        [Fact]
        public async Task DeleteBookAsync_ShouldReturnFailure_WhenIdDoesNotExists()
        {
            //arrange
            Guid id = Guid.NewGuid();
            _unitOfWorkMock.Setup(
                x => x.Book.FindByIdAsync(id))
                .ReturnsAsync((Book)null!);

            //act
            var result = await _sut.DeleteBookAsync(id);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
            _unitOfWorkMock.Verify(
                x => x.Book.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
            _unitOfWorkMock.Verify(
                x => x.Book.DeleteAsync(It.IsAny<Book>()), Times.Never);
            _unitOfWorkMock.Verify(tmp => tmp.SaveChangesAsync(), Times.Never);
        }

        #endregion

        #region GetBooksByFiltersAsync
        [Fact]
        public async Task GetBooksByFiltersAsync_ShouldReturnSuccessWithBooks_WhenRequestDataIsValid()
        {
            //Arrange
            var request = _fixture.Create<BookSearchCriteria>();
            var fakeBooks = _fixture.CreateMany<Book>(20).ToList();

            _unitOfWorkMock.Setup(
                x=> x.Book.FindAllByCriteriaAsync(It.IsAny<ISpecification<Book>>()))
                .ReturnsAsync(fakeBooks);

            //act
            var result = await _sut.GetBooksByFiltersAsync(request);

            //assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Should().HaveCount(20);
            _unitOfWorkMock.Verify(
                x => x.Book.FindAllByCriteriaAsync(It.IsAny<ISpecification<Book>>())
                , Times.Once);

        }

        [Fact]
        public async Task GetBooksByFiltersAsync_ShouldThrowArgumentNullException_WhenRequestIsNull()
        {
            await _sut.Invoking(x => x.GetBooksByFiltersAsync(null!))
              .Should().ThrowAsync<ArgumentNullException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(51)]
        [InlineData(-51)]
        [InlineData(12000)]
        [InlineData(-12000)]
        public async Task GetBooksByFiltersAsync_ShouldReturnFailure_WhenPageSizeIsGreaterThan50OrLowerThan1(int pageSize)
        {
            //arrange
            var request = _fixture.Build<BookSearchCriteria>()
                .With(tmp => tmp.PageSize, pageSize)
                .Create();
            //act
            var result = await _sut.GetBooksByFiltersAsync(request);
            
            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-51)]
        [InlineData(-12000)]
        public async Task GetBooksByFiltersAsync_ShouldReturnFailure_WhenPageNumerIsLowerThanOne(int pageNumber)
        {
            //arrange
            var request = _fixture.Build<BookSearchCriteria>()
                .With(tmp => tmp.PageNumber, pageNumber)
                .Create();
            //act
            var result = await _sut.GetBooksByFiltersAsync(request);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().NotBeNullOrEmpty();
        }
        [Theory]
        [InlineData("abc")]
        [InlineData("nfdasoifeuife")]
        [InlineData("")]
        public async Task GetBooksByFiltersAsync_ShouldReturnSuccessWithEmptyResultValue_WhenSearchTermDoesNotExists(string searchTerm)
        {
            //arrange
            var request = _fixture.Build<BookSearchCriteria>()
                .With(tmp => tmp.SearchTerm, searchTerm)
                .Create();
            var emptyList = new List<Book>();
            _unitOfWorkMock.Setup(
                tmp => tmp.Book.FindAllByCriteriaAsync(It.IsAny<ISpecification<Book>>()))
                .ReturnsAsync(emptyList);

            //act
            var result = await _sut.GetBooksByFiltersAsync(request);

            //assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEmpty();
        }
        [Theory]
        [InlineData("abc")]
        [InlineData("nfdasoifeuife")]
        [InlineData("")]
        public async Task GetBooksByFiltersAsync_ShouldReturnSuccessAndUseDefaultSortByTitle_WhenSortByDoesNotExists(string sortBy)
        {
            //arrange
            var request = _fixture.Build<BookSearchCriteria>()
                .With(tmp => tmp.SortBy, sortBy)
                .Create();
            var fakeBooks = _fixture.CreateMany<Book>(20).ToList();
            ISpecification<Book> capturedSpec = null!;

            _unitOfWorkMock.Setup(
                tmp => tmp.Book.FindAllByCriteriaAsync(It.IsAny<ISpecification<Book>>()))
                .Callback<ISpecification<Book>>(spec => capturedSpec = spec )
                .ReturnsAsync(fakeBooks);

            //act
            var result = await _sut.GetBooksByFiltersAsync(request);

            //assert
            capturedSpec.Should().NotBeNull();
            var orderByExpression = capturedSpec.OrderBy?.ToString();
            orderByExpression.Should().Contain("b.Title");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().HaveCount(20);
        }
        #endregion
    }
}
