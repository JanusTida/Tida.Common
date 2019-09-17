using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Util {
    /// <summary>
    /// 原始Tida.Util价转换接口;
    /// 目的:存储不能直接被序列化的对象类型的重要信息,减少对原始数据类型的 注解属性(比如NewtonSoft相关注解)代码,避免原始数据类型与序列化方式直接耦合;
    /// </summary>
    /// <typeparam name="TObject">原始数据类型</typeparam>
    /// /// <typeparamref name="TEntity"/>能够与原始数据类型做等价转换,且能够被序列化方式直接处理的存储类型</summary>
    public interface IObjectEntityConverter<TObject,TEntity>:IObjectEntityConverter  {
        /// <summary>
        /// 从数据类型转换为存储模型;
        /// </summary>
        /// <param name="tObject"></param>
        /// <returns></returns>
        TEntity ConvertObjectToEntity(TObject tObject);
        
        /// <summary>
        /// 从存储模型转换为数据类型;
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TObject ConvertEntityToObject(TEntity entity);
    }

    /// <summary>
    /// 等价转换接口;
    /// </summary>
    public interface IObjectEntityConverter {
        /// <summary>
        /// 原始类型;
        /// </summary>
        Type ObjectType { get; }

        /// <summary>
        /// 存储类型;
        /// </summary>
        Type EntityType { get; }

        /// <summary>
        /// 从原始类型转换为存储模型;
        /// </summary>
        /// <param name="tObject"></param>
        /// <returns></returns>
        object ConvertObjectToEntity(object tObject);

        /// <summary>
        /// 从存储模型转换为原始类型;
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        object ConvertEntityToObject(object entity);
        
    }

}
