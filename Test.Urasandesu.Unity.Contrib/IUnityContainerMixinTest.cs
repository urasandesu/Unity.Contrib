/* 
 * File: IUnityContainerMixinTest.cs
 * 
 * Author: Akira Sugiura (urasandesu@gmail.com)
 * 
 * 
 * Copyright (c) 2017 Akira Sugiura
 *  
 *  This software is MIT License.
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *  THE SOFTWARE.
 */



using Microsoft.Practices.Unity;
using NUnit.Framework;
using Urasandesu.Unity.Contrib;

namespace Test.Urasandesu.Unity.Contrib
{
    [TestFixture]
    public class IUnityContainerMixinTest
    {
        [Test]
        public void RegisterTypeIfMissingOfT_should_register_T_if_it_has_not_been_registered_yet()
        {
            // Arrange
            var container = new UnityContainer();

            // Act
            container.RegisterTypeIfMissing<A>(new InjectionConstructor(42));

            // Assert
            var a = container.Resolve<A>();
            Assert.AreEqual(42, a.Value);
        }

        [Test]
        public void RegisterTypeIfMissingOfT_should_not_register_T_if_it_has_already_been_registered()
        {
            // Arrange
            var container = new UnityContainer();
            container.RegisterTypeIfMissing<A>(new InjectionConstructor(42));

            // Act
            container.RegisterTypeIfMissing<A>(new InjectionConstructor(13));

            // Assert
            var a = container.Resolve<A>();
            Assert.AreEqual(42, a.Value);
        }



        [Test]
        public void RegisterTypeIfMissingOfTFromOfTTo_should_register_TFrom_if_it_has_not_been_registered_yet()
        {
            // Arrange
            var container = new UnityContainer();

            // Act
            container.RegisterTypeIfMissing<IA, A>(new InjectionConstructor(42));

            // Assert
            var a = container.Resolve<A>();
            Assert.AreEqual(42, a.Value);
        }

        [Test]
        public void RegisterTypeIfMissingOfTFromOfTTo_should_not_register_TFrom_if_it_has_already_been_registered()
        {
            // Arrange
            var container = new UnityContainer();
            container.RegisterTypeIfMissing<IA, A>(new InjectionConstructor(42));

            // Act
            container.RegisterTypeIfMissing<IA, A>(new InjectionConstructor(13));

            // Assert
            var a = container.Resolve<A>();
            Assert.AreEqual(42, a.Value);
        }



        public interface IA
        {
            int Value { get; }
        }

        public class A : IA
        {
            public A(int value)
            {
                Value = value;
            }

            public int Value { get; }
        }
    }
}
