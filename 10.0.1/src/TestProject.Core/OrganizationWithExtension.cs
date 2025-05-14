using Abp.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class OrganizationWithExtension : OrganizationUnit
    {
        public virtual long ParentId1 { get; set; }
        public virtual long ParentId2 { get; set; }

    }
}
