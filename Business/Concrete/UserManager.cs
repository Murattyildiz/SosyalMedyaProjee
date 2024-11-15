﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConncerns.Logging.Log4Net.Logger;
using Core.Entities.Concrete;
using Core.Utulities.Business;
using Core.Utulities.Result.Abstract;
using Core.Utulities.Result.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [LogAspect(typeof(FileLogger))]
        //[SecuredOperation("admin,user")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User entity)
        {
            var rulesResult = BusinessRules.Run(CheckIfEmailExist(entity.Email));
            if(rulesResult != null)
            {
                return rulesResult;
            }
            _userDal.Add(entity);
            return new SuccessResult(Messages.UserAdded);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(int id)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserIdExist(id));
            if (rulesResult != null)
            {
                return rulesResult;
            }
            var deletedUser = _userDal.Get(x => x.Id == id);
            _userDal.Delete(deletedUser);
            return new SuccessResult(Messages.UserDeleted);

        }
        public IResult Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
        }

        public IDataResult<List<UserDto>> GetAllDto()
        {
            return new SuccessDataResult<List<UserDto>>(_userDal.GetUserDtos(), Messages.UsersListed);
        }

        public IDataResult<User> GetEntityById(int id)
        {
            var user=_userDal.Get(x=>x.Id == id);
            if(user!= null)
            {
                return new SuccessDataResult<User>(user, Messages.UserListed);
            }
            return new ErrorDataResult<User>(Messages.UserNotExist);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserIdExist(user.Id));
            if (rulesResult != null)
            {
                return new ErrorDataResult<List<OperationClaim>>(rulesResult.Message);
            }
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetUserByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Email == email));
        }

        public IDataResult<UserDto> GetUserDtoById(int userId)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUserDtos(x=>x.Id == userId).SingleOrDefault(),Messages.UserListed);
        }
        [LogAspect(typeof(FileLogger))]
        // [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User entity)
        {
           var result=BusinessRules.Run(CheckIfUserIdExist(entity.Id), CheckIfEmailAvailable(entity.Email));
            if (result != null)
            {
                return result;
            }
            _userDal.Update(entity);
            return new SuccessResult(Messages.UserUpdated);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        //[ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult UpdateByDto(UserDto userDto)
        {
           var rulesResult=BusinessRules.Run(CheckIfUserIdExist(userDto.Id), CheckIfEmailAvailable(userDto.Email));
            if (rulesResult != null)
            {
                return rulesResult;
            }
           var updatedUser=_userDal.Get(x => x.Id == userDto.Id && x.Email==userDto.Email);
            if(updatedUser == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            updatedUser.FirstName = userDto.FirstName;
            updatedUser.LastName = userDto.LastName;
            _userDal.Update(updatedUser);
            return new SuccessResult(Messages.UserUpdated);

        }
        //Business Rules
         private IResult CheckIfUserIdExist(int userId)
        {
            var result = _userDal.GetAll(x => x.Id == userId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.UserNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfEmailExist(string userEmail)
        {
            var result = BaseCheckIfEmailExist(userEmail);
            if (result)
            {
                return new ErrorResult(Messages.UserEmailExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfEmailAvailable(string userEmail)
        {
            var result = BaseCheckIfEmailExist(userEmail);
            if (!result)
            {
                return new ErrorResult(Messages.userEmailNotAvailable);
            }
            return new SuccessResult();
        }

        private bool BaseCheckIfEmailExist(string userEmail)
        {
            return _userDal.GetAll(x => x.Email == userEmail).Any();
        }

       
    }
}
