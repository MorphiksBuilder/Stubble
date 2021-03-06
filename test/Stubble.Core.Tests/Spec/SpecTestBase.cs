﻿// <copyright file="SpecTestBase.cs" company="Stubble Authors">
// Copyright (c) Stubble Authors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections;
using Xunit;
using Xunit.Abstractions;

namespace Stubble.Core.Tests.Spec
{
    public class SpecTestBase
    {
        internal readonly ITestOutputHelper OutputStream;

        public SpecTestBase(ITestOutputHelper output)
        {
            OutputStream = output;
        }

        public void It_Can_Pass_Spec_Tests(SpecTest data)
        {
            OutputStream.WriteLine(data.name);
            var stubble = new StubbleVisitorRenderer();
            var output = data.partials != null ? stubble.Render(data.template, data.data, data.partials) : stubble.Render(data.template, data.data);

            OutputStream.WriteLine("Expected \"{0}\", Actual \"{1}\"", data.expected, output);
            Assert.Equal(data.expected, output);
        }
    }
}
