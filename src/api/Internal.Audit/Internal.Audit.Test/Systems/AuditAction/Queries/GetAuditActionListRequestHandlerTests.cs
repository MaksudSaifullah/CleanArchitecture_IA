﻿using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditActions;
using Internal.Audit.Application.Features.AuditAction.Queries.GetActionList;
using Internal.Audit.Application.Mappings;
using Internal.Audit.Test.MockDatas;
using Internal.Audit.Test.MockRepositories;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Internal.Audit.Test.Systems.Action.Queries
{
    public class GetAuditActionListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAuditActionQueryRepository> _mockRepo;
        private readonly GetAuditActionListQuery _actionListRequest;
        // private readonly GetCountryQuery _countryRequest;

        public GetAuditActionListRequestHandlerTests()
        {
            AuditActionMockData.AddActionStatic();
            _mockRepo = MockAuditActionRepository.GetAllActions();


            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }


        [Fact]
        public async Task GetActionList()
        {
            ///arrange 
            var handler = new GetAuditActionListQueryHandler(_mockRepo.Object, _mapper);

            ///act
            var result = await handler.Handle(_actionListRequest, CancellationToken.None);

            ///assert
            result.ShouldBeOfType<List<GetAuditActionListResponseDTO>>();

            result.Count().ShouldBe(3);
        }
    }

      
}
