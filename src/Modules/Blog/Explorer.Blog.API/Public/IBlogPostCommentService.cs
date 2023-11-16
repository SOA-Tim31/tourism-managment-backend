﻿using Explorer.Blog.API.Dtos;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.API.Public
{
    public interface IBlogPostCommentService
    {
        Result<PagedResult<BlogPostCommentDto>> GetPaged(int page, int pageSize);
        Result<BlogPostCommentDto> Create(BlogPostCommentDto equipment);
        Result<BlogPostCommentDto> Update(BlogPostCommentDto equipment);
        Result Delete(int id);
    }
}