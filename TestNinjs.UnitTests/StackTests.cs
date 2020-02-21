using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowArgumentNullException()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Push(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Push_ArgIsValud_AddNewObjectToStack()
        {
            var stack = new Stack<string>();

            stack.Push("123");

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();

            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<int>();

            Assert.That(() => stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<int>();

            Assert.That(() => stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_FewObjectsInStack_ShoudReturnLastObject()
        {
            var stack = new Stack<object>();
            var obj = new Object();
            var obj2 = new Object();

            stack.Push(obj);
            stack.Push(obj2);

            Assert.That(() => stack.Peek(), Is.EqualTo(obj2));
        }

        [Test]
        public void Pop_OneObjectInStack_ShoudReturnThisObject()
        {
            var stack = new Stack<object>();
            var obj = new Object();

            stack.Push(obj);

            Assert.That(() => stack.Pop(), Is.EqualTo(obj));
        }

        [Test]
        public void Pop_OneObjectInStack_ShoudReturnZeroCount()
        {
            var stack = new Stack<object>();
            var obj = new Object();

            stack.Push(obj);
            stack.Pop();

            Assert.That(() => stack.Count, Is.EqualTo(0));
        }
    }
}
