using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;

namespace BookStoreUI
{
    public class DependencyRegister:StructureMap.Registry
    {
        public DependencyRegister()
        {
            Scan(scan =>
            {
                scan.AssembliesAndExecutablesFromApplicationBaseDirectory();
                scan.WithDefaultConventions();
            });
        }
    }
}
