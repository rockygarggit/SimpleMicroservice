using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Consts
{
    public class RouteConsts
    {

        public const string ROUTE_API_BASE = "/api";

        public const string ROUTE_USER_BASE = ROUTE_API_BASE + "/Profile";
        public const string ROUTE_USER_GET_ONE_BY_UUID = ROUTE_USER_BASE + "/{uuid}";
    }

}

