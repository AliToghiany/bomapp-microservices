using AutoMapper;
using dotnet_lib.Models;
using dotnet_lib.Models.Response;
using dotnet_lib.Models.Response.Search;
using dotnet_lib.Services.Interface;
using dotnet_lib.Utitlities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lib.Context;
using wpf_lib.Entity;
using wpf_lib.Interface;

namespace wpf_lib.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public UserRepository(IUserService userService, ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _userService = userService;
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public Task<ResultDto<AppResponseChatSearch>> GetLastSearchAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto<GetMyUserProfileResponse>> GetMyUserProfile()
        {
            
            var user= await  _applicationDbContext.Users.Include(p=>p.ImageProfiles).FirstOrDefaultAsync(p=>p.Id==dotnet_lib.App.UserId);
            if (user != null) {
                var res = _mapper.Map<GetMyUserProfileResponse>(user);
                res.ImagesProfileResponses = user.ImageProfiles.Select(p => new ImagesProfileResponse
                {
                    Name = p.Name,
                    Path = p.Path,


                }).ToList();
                return new ResultDto<GetMyUserProfileResponse>
                {
                    IsSuccess = true,
                    Data = res
                };
            }


            return new ResultDto<GetMyUserProfileResponse>
            {
                IsSuccess=false,
                Message="Not Found My Profile"

            };


        }

        public async Task<ResultDto<ResponseUser>> GetUser(long Id)
        {
            var res= await _applicationDbContext.Users.Include(p => p.ImageProfiles)
                .FirstOrDefaultAsync(p => p.Id == Id);
            if (res == null)
            {
                return new ResultDto<ResponseUser>
                {
                    IsSuccess = false,
                    Message = "Not Found",
                   
                };
            }
            var responsRes=_mapper.Map<ResponseUser>(res);
            responsRes.ImagesProfileResponses = res.ImageProfiles.Select(p => new ImagesProfileResponse
            {
                Name = p.Name,
                Path = p.Path
            }).ToList();
            return new ResultDto<ResponseUser>
            {
                IsSuccess = true,
                Data = responsRes
            };
        }
        public async Task<ResultDto> NewUser(User user)
        {
            await _applicationDbContext.Users.AddAsync(user);
            await _applicationDbContext.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true
            };
        }
        public async Task<ResultDto> NewImageProfile(ImageProfile imageProfile)
        {
            await _applicationDbContext.ImageProfiles.AddAsync(imageProfile);
            return new ResultDto
            {
                IsSuccess = true
            };
        }
     


        public async Task<ResultDto> UpdateUser(ResponseUser responseUser)
        {
            var res =await _applicationDbContext.Users.Include(p=>p.ImageProfiles).FirstOrDefaultAsync(p=>p.Id==responseUser.Id);
            if (res is null) { 
                var newRes=await NewUser(_mapper.Map<User>(responseUser));
                return newRes;
            }
            res.Phone = responseUser.PhoneNumber;
            res.FirstName = responseUser.FirstName;
            res.UserName = responseUser.UserName;
            foreach (var item in responseUser.ImagesProfileResponses)
            {
          
                if (res.ImageProfiles.FirstOrDefault(p=>p.Name==item.Name) == null)
                {
                   await NewImageProfile(new ImageProfile { UserId=res.Id,Name=item.Name,Path=item.Path});
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true
            };
            
        }

        public async Task<ResultDto> UpdateUser(GetMyUserProfileResponse responseUser)
        {
            var res = await _applicationDbContext.Users.Include(p => p.ImageProfiles).FirstOrDefaultAsync(p => p.Id == responseUser.Id);
            if (res is null)
            {
                var newRes = await NewUser(_mapper.Map<User>(responseUser));
                return newRes;
            }
            res.Phone = responseUser.PhoneNumber;
            res.FirstName = responseUser.FirstName;
            res.UserName = responseUser.UserName;
            res.Description = responseUser.Description;
            _applicationDbContext.Users.Update(res);
           
            foreach (var item in responseUser.ImagesProfileResponses)
            {

                if (res.ImageProfiles.FirstOrDefault(p => p.Name == item.Name) == null)
                {
                    await NewImageProfile(new ImageProfile { UserId = res.Id, Name = item.Name, Path = item.Path });
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
