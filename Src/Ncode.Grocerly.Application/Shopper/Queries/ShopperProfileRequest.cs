using MediatR;
using Ncode.Grocerly.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ncode.Grocerly.Application.Queries
{
    public class ShopperProfileRequest : IRequest<ShopperProfileResponse>
    {
        public string Username { get; set; }
    }
}
