using DataFactory.BaseFactory;
using DataModels.EntityModels.OraModel;
using DataModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataFactory.AllServiceClasses
{
    public class CmnUser_EF : GenericFactoryEF<ModelContext, vmCmnParameter> { }
}
