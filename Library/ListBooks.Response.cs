using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using A19029.Services.Framework.Executor;
 using AutoMapper;
namespace Service.Library
{
    public class ListBooksResponse : DataResponse
    {

        public ListBooksResponse()
        {

        }

        public ListBooksResponse(DataResponse aObject)
        {
            var lConfig = new MapperConfiguration(aR => aR.CreateMap<DataResponse, ListBooksResponse>());
            IMapper lMapper = lConfig.CreateMapper();

            lMapper.Map<DataResponse, ListBooksResponse>(aObject, this);
        }
    }
}