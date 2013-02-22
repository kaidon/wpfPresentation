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
            model.BlockName = null;
            Assert.IsFalse(model.PushA.CanExecute(null));
            model.BlockName = "";
            Assert.IsFalse(model.PushA.CanExecute(null));
            model.BlockName = "   ";
            Assert.IsFalse(model.PushA.CanExecute(null));
        }

        [TestMethod]
        public void Push_AddsNametoStackA()
        {
            Push("aaa", "bbb", "ccc");
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
            Push("aaa","bbb","ccc");            
            PopAndCheckStacks(new[] {"aaa", "bbb"}, new[] {"ccc"});
            PopAndCheckStacks(new[] {"aaa"}, new[] {"ccc", "bbb"});
            PopAndCheckStacks(new string[0], new[] {"ccc", "bbb", "aaa"});
        }

        private void Push(params string[] blockNames)
        {
            foreach (var b in blockNames)
            {
                model.BlockName = b;
                model.PushA.Execute(null);
            }
        }

        private void PopAndCheckStacks(string[] expectStackA, string[] expectStackB)
        {
            model.PopA.Execute(null);
            CollectionAssert.AreEquivalent(expectStackA, model.StackA);
            CollectionAssert.AreEquivalent(expectStackB, model.StackB);
        }
    }
}
