using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;
 using AutoMapper;
namespace Service.Library
{
    public class GetBookResponse : BookDTO
    {

        public GetBookResponse()
        {

        }

        public GetBookResponse(BookDTO aObject)
        {
            var lConfig = new MapperConfiguration(aR => aR.CreateMap<BookDTO, GetBookResponse>());
            IMapper lMapper = lConfig.CreateMapper();

            lMapper.Map<BookDTO, GetBookResponse>(aObject, this);
        }
    }
}