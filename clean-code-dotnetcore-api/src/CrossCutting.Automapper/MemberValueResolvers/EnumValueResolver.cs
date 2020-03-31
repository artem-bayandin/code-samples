﻿using AutoMapper;
using CrossCutting.Automapper.Extensions;
using CrossCutting.Automapper.Models;
using System;

namespace CrossCutting.Automapper.MemberValueResolvers
{
    public class EnumValueResolver<T> : IMemberValueResolver<object, object, T, EnumModel>
    {
        public EnumModel Resolve(object source, object destination, T sourceMember, EnumModel destMember, ResolutionContext context)
        {
            return (sourceMember as Enum).ConvertToEnumModel();
        }
    }
}
