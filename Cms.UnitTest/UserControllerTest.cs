using Cms.Shared.Bases.Dtos.ResponseModel;
using FluentAssertions;
using MediatR;
using Moq;
using UserService.Api.Controllers;
using UserService.Application.Feature.User.Commands.CreateUser;
using UserService.Application.Feature.User.Commands.DeleteUser;
using UserService.Application.Feature.User.Commands.UpdateUser;
using UserService.Application.Feature.User.Queries.GetAllUser;
using UserService.Application.Feature.User.Queries.GetByIdUser;

namespace Cms.UnitTest
{
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly Mock<IMediator> _mediatorMock;

        public UserControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new UserController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnResponseDtoWithUserList()
        {

            var expectedResponse = new ResponseDto<IList<GetAllUserQueryResponse>>
            {
                Data = new List<GetAllUserQueryResponse> { new GetAllUserQueryResponse() }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllUserQueryRequest>(), default))
                         .ReturnsAsync(expectedResponse);


            var result = await _controller.GetAllAsync();


            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnResponseDtoWithUser()
        {

            var userId = 1;
            var expectedResponse = new ResponseDto<GetByIdUserQueryResponse>
            {
                Data = new GetByIdUserQueryResponse()
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetByIdUserQueryRequest>(), default))
                         .ReturnsAsync(expectedResponse);

          
            var result = await _controller.GetByIdAsync(userId);

          
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResponseDtoWithCreateUserCommandResponse()
        {

            var request = new CreateUserCommandRequest("test","test@test.com");
            var expectedResponse = new ResponseDto<CreateUserCommandResponse>
            {
                Data = new CreateUserCommandResponse()
            };
            _mediatorMock.Setup(m => m.Send(request, default))
                         .ReturnsAsync(expectedResponse);

            
            var result = await _controller.CreateAsync(request);


            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResponseDtoWithDeleteUserCommandResponse()
        {
            
            var userId = 1;
            var expectedResponse = new ResponseDto<DeleteUserCommandResponse>
            {
                Data = new DeleteUserCommandResponse()
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteUserCommandRequest>(), default))
                         .ReturnsAsync(expectedResponse);

            
            var result = await _controller.DeleteAsync(userId);

            
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResponseDtoWithUpdateUserCommandResponse()
        {
            
            var request = new UpdateUserCommandRequest(1,"test","test@test.com");
            var expectedResponse = new ResponseDto<UpdateUserCommandResponse>
            {
                Data = new UpdateUserCommandResponse()
            };
            _mediatorMock.Setup(m => m.Send(request, default))
                         .ReturnsAsync(expectedResponse);

         
            var result = await _controller.UpdateAsync(request);

         
            result.Should().BeEquivalentTo(expectedResponse);
        }
    }

}
