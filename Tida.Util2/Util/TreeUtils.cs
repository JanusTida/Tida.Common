using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Util {
    /// <summary>
    /// 树的相关拓展方法;
    /// </summary>
    public static class TreeUtils {
        /// <summary>
        /// 深度优先遍历某个节点;
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="root"></param>
        /// <param name="getChilren"></param>
        /// <returns></returns>
        public static IEnumerable<TEntity> DepthFirstTraverse<TEntity>(TEntity root, Func<TEntity, IEnumerable<TEntity>> getChilren) {
            if (EqualityComparer<TEntity>.Default.Equals(root, default)) {
                throw new ArgumentNullException(nameof(root));
            }

            if (getChilren == null) {
                throw new ArgumentNullException(nameof(getChilren));
            }

            var entityStack = new Stack<TEntity>();
            entityStack.Push(root);

            TEntity entityNode = default;
            while (entityStack.Count != 0) {
                entityNode = entityStack.Pop();
                yield return entityNode;
                foreach (var childNode in getChilren(entityNode)) {
                    entityStack.Push(childNode);
                }
            }
        }

        /// <summary>
        /// 广度优先遍历某个节点;
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="root"></param>
        /// <param name="getChilren"></param>
        /// <returns></returns>
        public static IEnumerable<TEntity> BreadthFirstTraverse<TEntity>(TEntity root, Func<TEntity, IEnumerable<TEntity>> getChilren) 
        {
            if (EqualityComparer<TEntity>.Default.Equals(root, default)) {
                throw new ArgumentNullException(nameof(root));
            }

            if (getChilren == null) {
                throw new ArgumentNullException(nameof(getChilren));
            }

            var entityQueue = new Queue<TEntity>();
            entityQueue.Enqueue(root);

            TEntity entityNode = default;
            while (entityQueue.Count != 0) {
                entityNode = entityQueue.Dequeue();
                yield return entityNode;
                foreach (var childNode in getChilren(entityNode)) {
                    entityQueue.Enqueue(childNode);
                }
            }

        }
    }

}
