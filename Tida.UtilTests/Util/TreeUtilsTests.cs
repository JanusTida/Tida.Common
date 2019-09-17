using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tida.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Util.Tests {
    [TestClass()]
    public class TreeUtilsTests {
        [TestMethod()]
        public void DepthFirstTraverseTest() {
            var rand = new Random();
            var root = new Node { Val = rand.Next(1000) };
            var child0 = new Node { Val = rand.Next(1000) };
            var child1 = new Node { Val = rand.Next(1000) };
            var child2 = new Node { Val = rand.Next(1000) };
            var children = new Node[] { child0, child1, child2 };
            root.Children.AddRange(children);
            var grandChild0 = new Node { Val = rand.Next(1000) };
            var grandChild1 = new Node { Val = rand.Next(1000) };
            var grandChildren = new Node[] { grandChild0, grandChild1 };
            child0.Children.AddRange(grandChildren);

            var allNodes = TreeUtils.DepthFirstTraverse(root, p => p.Children).ToArray();
            Assert.IsNotNull(allNodes);
            Assert.AreEqual(allNodes.Length, children.Length + grandChildren.Length + 1);
            Assert.AreEqual(allNodes.Sum(p => p.Val), children.Union(grandChildren).Sum(p => p.Val) + root.Val);

            allNodes = TreeUtils.BreadthFirstTraverse(root, p => p.Children).ToArray();
            Assert.IsNotNull(allNodes);
            Assert.AreEqual(allNodes.Length, children.Length + grandChildren.Length + 1);
            Assert.AreEqual(allNodes.Sum(p => p.Val), children.Union(grandChildren).Sum(p => p.Val) + root.Val);
        }


        class Node {
            public List<Node> Children { get; } = new List<Node>();
            public int Val { get; set; }
        }
    }
}