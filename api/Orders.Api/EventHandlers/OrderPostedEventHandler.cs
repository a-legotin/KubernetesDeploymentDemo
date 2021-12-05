using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Bus.Abstractions;
using Common.Bus.Events;
using Microsoft.Extensions.Logging;
using Orders.Api.Database.Models;
using Orders.Api.Database.Repository;

namespace Orders.Api.EventHandlers
{
    public class OrderPostedEventHandler : IIntegrationEventHandler<OrderPostedEvent>
    {
        private readonly ILogger<OrderPostedEventHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _postsRepository;

        public OrderPostedEventHandler(ILogger<OrderPostedEventHandler> logger,
            IOrdersRepository postsRepository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        public async Task Handle(OrderPostedEvent request)
        {
            _logger.LogTrace("Got an event {request.Id} created at {request.CreationDate}");
            await _postsRepository.InsertAsync(_mapper.Map<OrderDto>(request.Order));
        }
    }
}