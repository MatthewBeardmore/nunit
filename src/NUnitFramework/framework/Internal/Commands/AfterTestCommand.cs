﻿// ***********************************************************************
// Copyright (c) 2017 Charlie Poole
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
using System.Threading;
using NUnit.Framework.Interfaces;

namespace NUnit.Framework.Internal.Commands
{
    /// <summary>
    /// AfterCommand is a DelegatingTestCommand that performs some
    /// specific action after the inner command is run.
    /// </summary>
    public abstract class AfterTestCommand : DelegatingTestCommand
    {
        /// <summary>
        /// Construct an AfterCommand
        /// </summary>
        public AfterTestCommand(TestCommand innerCommand) : base(innerCommand) { }

        /// <summary>
        /// Execute the command
        /// </summary>
        public override TestResult Execute(TestExecutionContext context)
        {
            Guard.OperationValid(AfterTest != null, "AfterTest was not set by the derived class constructor");

            innerCommand.Execute(context);

            AfterTest(context);

            return context.CurrentResult;
        }

        /// <summary>
        /// Set this to perform action after the inner command.
        /// </summary>
        protected Action<TestExecutionContext> AfterTest;
    }
}
