﻿using System.Collections.Generic;
using System.Reflection;

namespace Umbraco.Core.Composing
{
    /// <summary>
    /// Provides a list of assemblies that can be scanned
    /// </summary>
    public interface IAssemblyProvider
    {
        IEnumerable<Assembly> Assemblies { get; }
    }
}
