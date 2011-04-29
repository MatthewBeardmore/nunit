﻿// ***********************************************************************
// Copyright (c) 2011 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.Xml;

namespace NUnit.Engine.Api
{
    /// <summary>
    /// ITestEngine represents an instance of the test engine.
    /// </summary>
    public interface ITestEngine
    {
        /// <summary>
        /// Returns an XML representation of the tests contained
        /// in a test package.
        /// </summary>
        /// <param name="package">The test package to be explored.</param>
        /// <returns>An XmlNode representing the tests.</returns>
        XmlNode Explore(TestPackage package);

        /// <summary>
        /// Runs the tests specified by a test package and returns
        /// results as an XmlNode.
        /// </summary>
        /// <param name="package">The test package to be run.</param>
        /// <param name="filter">A test filter indicating which tests should run.</param>
        /// <returns>An XmlNode representing the results of the run.</returns>
        XmlNode Run(TestPackage package, TestFilter filter);

        /// <summary>
        /// Returns a runner suitable for running tests in the specified package.
        /// </summary>
        /// <param name="package">The TestPackage for which a runner is needed.</param>
        /// <returns>An ITestRunner, which may be local or remote depending on the package settings.</returns>
        ITestRunner GetRunner(TestPackage package);
    }
}