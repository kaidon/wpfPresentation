using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfTechTalk;

namespace WpfTechTalkTest
{
    [TestClass]
    public class StackAndPopTest
    {
        private StackAndPop model;

        [TestInitialize]
        public void setup()
        {
            model = new StackAndPop();
        }

        [TestMethod]
        public void Push_CannotExecute_WhenBlockNameEmpty()
        {
            Assert.IsFalse(model.PushA.CanExecute(null));
            Assert.IsFalse(model.PushA.CanExecute(""));
            Assert.IsFalse(model.PushA.CanExecute("    "));
        }

        [TestMethod]
        public void Push_AddsNametoStackA()
        {
            model.PushA.Execute("aaa");
            model.PushA.Execute("bbb");
            model.PushA.Execute("ccc");
            CollectionAssert.AreEquivalent(new[] {"aaa", "bbb", "ccc"}, model.StackA);
        }

        [TestMethod]
        public void Pop_CannotExecute_WhenStackA_Empty()
        {
            Assert.IsTrue(model.StackA.Count == 0);
            Assert.IsFalse(model.PopA.CanExecute(null));
        }

        [TestMethod]
        public void Pop_PutsLastItem_OnStackB()
        {
            model.PushA.Execute("aaa");
            model.PushA.Execute("bbb");
            model.PushA.Execute("ccc");
            PopAndCheckStacks(new[] {"aaa", "bbb"}, new[] {"ccc"});
            PopAndCheckStacks(new[] {"aaa"}, new[] {"ccc", "bbb"});
            PopAndCheckStacks(new string[0], new[] {"ccc", "bbb", "aaa"});
        }

        private void PopAndCheckStacks(string[] expectStackA, string[] expectStackB)
        {
            model.PopA.Execute(null);
            CollectionAssert.AreEquivalent(expectStackA, model.StackA);
            CollectionAssert.AreEquivalent(expectStackB, model.StackB);
        }
    }
}
