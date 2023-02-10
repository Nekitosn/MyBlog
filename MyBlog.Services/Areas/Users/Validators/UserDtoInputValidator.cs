﻿using FluentValidation;
using MyBlog.Service.Areas.Users.AutoMapper.Dto;

namespace MyBlog.Service.Areas.Users.Validators;

public class UserDtoInputValidator : AbstractValidator<UserDtoInput>
{
    public UserDtoInputValidator()
    {
        RuleFor(user => user.FirstName)
            .Length(2, 30).WithMessage("Length must be between 2 characters and 30")
            .Must(name => !name.Contains(' ')).WithMessage("Entering without whitespace");

        RuleFor(user => user.LastName)
            .Length(2, 30).WithMessage("Length must be between 2 characters and 30")
            .Must(name => !name.Contains(' ')).WithMessage("Entering without whitespace")
            .NotEqual(user => user.FirstName).WithMessage("Must not match with 'Name'");

        RuleFor(user => user.Password)
            .Length(6, 50).WithMessage("Length must be between 6 characters and 30")
            .Must(name => !name.Contains(' ')).WithMessage("Entering without whitespace");

        RuleFor(user => user.Email)
            .MaximumLength(50).WithMessage("The maximum length must not exceed 50")
            .EmailAddress();
        
        RuleFor(user => user.Phone)
            .Matches(@"^\+380\d{9}$").WithMessage($"Wrong format, example number phone: '+3802887231");
    }
}