﻿using IBusiness.Common;

namespace UnityInterfaces
{
    public static class RegisterInterfaces
    {
        public static IFacadeProvider LFacadeProvider { get; set; }
        public static IFacadeProvider RegisTerFacade()
        {
            LFacadeProvider = new Bll_Business.Common.FacadeProvider();
            return LFacadeProvider;
        }
    }
}
