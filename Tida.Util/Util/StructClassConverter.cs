using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.Util.Util {
    /// <summary>
    /// 结构体-类转化器契约,,旨在减少检查参数的重复性代码;
    /// </summary>
    /// <typeparam name="TObject">原始类型(结构体)</typeparam>
    /// <typeparam name="TEntity">存储类型(引用类型)</typeparam>
    public abstract class StructClassConverter<TObject, TEntity> : IObjectEntityConverter<TObject, TEntity> where TObject : struct where TEntity : class {
        public Type ObjectType => typeof(TObject);

        public Type EntityType => typeof(TEntity);

        public TEntity ConvertObjectToEntity(TObject tObject) {
            return OnCreateEntityFromObject(tObject);
        }

        public TObject ConvertEntityToObject(TEntity entity) {
            if(entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }

            return OnCreateObjectFromEntity(entity);
        }


        protected abstract TEntity OnCreateEntityFromObject(TObject tObject);

        protected abstract TObject OnCreateObjectFromEntity(TEntity entity);

        public object ConvertObjectToEntity(object value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            if (!(value is TObject tObject)) {
                throw new InvalidCastException($"{value} is not a instance of {typeof(TObject)}.");
            }

            return ConvertObjectToEntity(tObject);
        }

        public object ConvertEntityToObject(object entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!(entity is TEntity tEntity)) {
                throw new InvalidCastException($"{entity} is not a instance of {typeof(TEntity)}.");
            }

            return ConvertEntityToObject(tEntity);
        }
    }
}
