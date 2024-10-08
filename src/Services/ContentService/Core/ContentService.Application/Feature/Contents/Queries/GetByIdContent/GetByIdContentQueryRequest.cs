﻿using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Queries.GetByIdContent
{
    public class GetByIdContentQueryRequest : IRequest<ResponseDto<GetByIdContentQueryResponse>>
    {
        public int Id { get; }
        public GetByIdContentQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
