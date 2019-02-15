﻿using MediatR;

namespace MyFirstAPI.Application.MongoDB.Commands
{
    public class CreateBrandCommand: IRequest<bool>
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
