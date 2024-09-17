using Cms.Shared.Bases.Dtos.ResponseModel;
using ContentService.Api.Controllers;
using ContentService.Application.Feature.Contents.Commands.CreateContent;
using ContentService.Application.Feature.Contents.Commands.DeleteContent;
using ContentService.Application.Feature.Contents.Commands.UpdateUser;
using ContentService.Application.Feature.Contents.Queries.GetAllContent;
using ContentService.Application.Feature.Contents.Queries.GetByIdContent;
using FluentAssertions;
using MediatR;
using Moq;

namespace Cms.UnitTest
{
    public class ContentControllerTests
    {
        private readonly ContentController _controller;
        private readonly Mock<IMediator> _mediatorMock;

        public ContentControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ContentController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnResponseDtoWithContentList()
        {

            var expectedResponse = new ResponseDto<IList<GetAllContentQueyResponse>>
            {
                Data = new List<GetAllContentQueyResponse> { new GetAllContentQueyResponse() }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllContentQueyRequest>(), default))
                         .ReturnsAsync(expectedResponse);


            var result = await _controller.GetAllAsync();


            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnResponseDtoWithContent()
        {

            var contentId = 1;
            var expectedResponse = new ResponseDto<GetByIdContentQueryResponse>
            {
                Data = new GetByIdContentQueryResponse()
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetByIdContentQueryRequest>(), default))
                         .ReturnsAsync(expectedResponse);


            var result = await _controller.GetByIdAsync(contentId);


            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResponseDtoWithCreateContentCommandResponse()
        {

            var request = new CreateContentCommandRequest("test", "test", "test", 1);
            var expectedResponse = new ResponseDto<CreateContentCommandResponse>
            {
                Data = new CreateContentCommandResponse()
            };
            _mediatorMock.Setup(m => m.Send(request, default))
                         .ReturnsAsync(expectedResponse);


            var result = await _controller.CreateAsync(request);


            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResponseDtoWithDeleteContentCommandResponse()
        {

            var contentId = 1;
            var expectedResponse = new ResponseDto<DeleteContentCommandResponse>
            {
                Data = new DeleteContentCommandResponse()
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteContentCommandRequest>(), default))
                         .ReturnsAsync(expectedResponse);


            var result = await _controller.DeleteAsync(contentId);


            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task UpdateUser_ShouldReturnResponseDtoWithUpdateUserCommandResponse()
        {

            var request = new UpdateUserCommandRequest(1, "");
            var expectedResponse = new ResponseDto<UpdateUserCommandResponse>
            {
                Data = new UpdateUserCommandResponse()
            };
            _mediatorMock.Setup(m => m.Send(request, default))
                         .ReturnsAsync(expectedResponse);


            var result = await _controller.UpdateUser(request);


            result.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
