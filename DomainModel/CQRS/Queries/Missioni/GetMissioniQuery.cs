﻿using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.Missioni
{
    public class GetMissioniQuery : IQuery<List<GetMissioniQueryResult>>
    {
    }
}
