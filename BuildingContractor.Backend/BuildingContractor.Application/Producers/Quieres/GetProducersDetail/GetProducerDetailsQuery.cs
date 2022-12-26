﻿using MediatR;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersDetail
{
    public class GetProducerDetailsQuery : IRequest<ProducerDetailsVm>
    {
        public int Id { get; set; }
    }
}
