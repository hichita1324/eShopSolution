﻿using eShopSolution.Application.Sales.Orders;
using eShopSolution.ViewModels.Sales;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    //api/orders
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CheckoutRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _orderService.Create(request);
            if (productId == 0)
                return BadRequest();

            return Ok(productId);
        }
    }
}