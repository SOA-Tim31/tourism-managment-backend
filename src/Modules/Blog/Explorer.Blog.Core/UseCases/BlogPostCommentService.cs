﻿using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.Core.UseCases
{
    public class BlogPostCommentService : CrudService<BlogPostCommentDto, BlogPostComment>, IBlogPostCommentService
    {
        public BlogPostCommentService(ICrudRepository<BlogPostComment> repository, IMapper mapper) : base(repository, mapper) { }        
    }
}