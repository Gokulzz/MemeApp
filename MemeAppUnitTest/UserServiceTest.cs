using System.ComponentModel.DataAnnotations;
using FluentValidation;
using memeApp.BLL.DTO;
using memeApp.BLL.Implementations;
using memeApp.DAL.Model;
using memeApp.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace MemeAppUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async void TestValidUserId()
        {
            //ARRANGE
            var mock_unitofWork= new Mock<IUnitofWork>();
            var mock_userRepository= new Mock<IUserRepository>();  
            var mock_userValidator = new Mock<IValidator<UserDTO>>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockContextAccessor = new Mock<IHttpContextAccessor>();
            Guid Id = Guid.Parse("B2648F8C-EA0E-4F55-B517-0554AFE8531E");
            mock_unitofWork.Setup(x=>x.userRepository).Returns(mock_userRepository.Object);
            mock_userRepository.Setup(x => x.Get(Id)).ReturnsAsync(new User
            {
                Id = Id,
                Email = "gokulkhatri2020@gmail.com",
                UserName = "gk",

            }); 
            var userService = new UserService(mock_unitofWork.Object, mock_userValidator.Object, mockConfiguration
                .Object, mockContextAccessor.Object);

            //ACT
            var result = await userService.GetUser(Id);
            var userResult = result.Result as User;
                //ASSERT
            Assert.NotNull(result);
            Assert.Equal("gokulkhatri2020@gmail.com", userResult.Email);

        }
        [Fact]
        public async void ReturnAllUser()
        {
            //ARRANGE
            var mock_unitofWork = new Mock<IUnitofWork>();
            var mock_userRepository = new Mock<IUserRepository>();
            var mock_userValidator = new Mock<IValidator<UserDTO>>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockContextAccessor = new Mock<IHttpContextAccessor>();
            var userService = new UserService(mock_unitofWork.Object, mock_userValidator.Object, mockConfiguration
               .Object, mockContextAccessor.Object);
            mock_unitofWork.Setup(x => x.userRepository).Returns(mock_userRepository.Object);
            mock_userRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<User>()
            {
                new User()
                {
                    Id= Guid.Parse("B2648F8C-EA0E-4F55-B517-0554AFE8531E"),
                    Email="sakulkhatri2020@gmail.com",
                    UserName="sk",
                    VerifiedAt=DateTime.UtcNow

                },
                new User()
                {
                    Id= Guid.Parse("B2648F8C-EA0E-4F55-B517-0554AFE8531D"),
                    Email="prabinkarki2020@gmail.com",
                    UserName="pk",
                    VerifiedAt=DateTime.UtcNow

                },
                new User()
                {
                    Id= Guid.Parse("B2648F8C-EA0E-4F55-B517-0554AFE8531C"),
                    Email="pujanprasai2020@gmail.com",
                    UserName="pk2",
                    VerifiedAt=DateTime.UtcNow
                },
                new User()
                {
                    Id= Guid.Parse("B2648F8C-EA0E-4F55-B517-0554AFE8532F"),
                    Email="gokulkhatri2020@gmail.com",
                    UserName="gk",
                    VerifiedAt=DateTime.UtcNow
                }
            }); 
            //ACT
            var result = await userService.GetAllUser();
            var userResult = result.Result as List<User>;

            //ASSERT
            Assert.NotNull(result);
            Assert.Equal(4, userResult.Count);

            

        }

        [Fact]
        public async void AddUser()
        {
       
                // ARRANGE
            var mock_unitofWork = new Mock<IUnitofWork>();
            var mock_userRepository = new Mock<IUserRepository>();
            var mock_userValidator = new Mock<IValidator<UserDTO>>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockContextAccessor = new Mock<IHttpContextAccessor>();

            var userService = new UserService(mock_unitofWork.Object, mock_userValidator.Object, mockConfiguration.Object, mockContextAccessor.Object);

            mock_unitofWork.Setup(x => x.userRepository).Returns(mock_userRepository.Object);

            var userDTO = new UserDTO("gokulkhatri2020@gmail.com", "Gokul123!@#", "Gokul123!@#", "Gokul");
            
            var user = new User()
            {
                Email = userDTO.Email,
                UserName = userDTO.UserName,
                
            };
            mock_userRepository.Setup(x => x.Post(user)).ReturnsAsync(user);
            //ACT
        
            var result = await userService.AddUser(userDTO);
            var userResult = result.Result as User;

            //ASSERT
            Assert.NotNull(result);
            Assert.Equal(user.Email,userResult.Email);
            

            
        }


        [Fact]
        public async void DeleteUser()
        {
            //ASSIGN
            var mock_unitofWork = new Mock<IUnitofWork>();
            var mock_userRepository = new Mock<IUserRepository>();
            var mock_userValidator = new Mock<IValidator<UserDTO>>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockContextAccessor = new Mock<IHttpContextAccessor>();
            var userService = new UserService(mock_unitofWork.Object, mock_userValidator.Object, mockConfiguration
               .Object, mockContextAccessor.Object);
            Guid id = Guid.Parse("B2648F8C-EA0E-4F55-B517-0554AFE8531E");
            mock_unitofWork.Setup(x=>x.userRepository).Returns(mock_userRepository.Object);
            mock_userRepository.Setup(x => x.Delete(id)).ReturnsAsync(new User()
            {
                Id = id, 
                Email = "gokulkhatri2020@gmail.com",
                UserName = "GK"
            });
           
            //ACT
            var result= await userService.DeleteUser(id);
            var userResult = result.Result as User;
            //ASSERT
            Assert.NotNull(result);
            Assert.Equal("gokulkhatri2020@gmail.com", userResult.Email);
            
            
            
        }
       
        
    }
}