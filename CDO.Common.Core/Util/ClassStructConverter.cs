using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDO.Common.Core.Util {
    /// <summary>
    /// 类-结构体转化器契约,,旨在减少检查参数的重复性代码;
    /// </summary>
    /// <typeparam name="TObject">原始类型(引用类型)</typeparam>
    /// <typeparam name="TEntity">存储类型(结构体)</typeparam>
    public abstract class ClassStructConverter<TObject, TEntity> : IObjectEntityConverter<TObject, TEntity> where TObject : class where TEntity : struct {
        public Type ObjectType => typeof(TObject);

        public Type EntityType => typeof(TEntity);

        public TEntity ConvertObjectToEntity(TObject tObject) {
            if (tObject == null) {
                throw new ArgumentNullException(nameof(tObject));
            }

            return OnCreateEntityFromObject(tObject);
        }

        public object CreateEntityFromObject(object tObject) {
            throw new NotImplementedException();
            
        }

        public TObject ConvertEntityToObject(TEntity entity) {
            

            return OnCreateObjectFromEntity(entity);
        }

        public object CreateObjectFromEntity(object entity) {
            throw new NotImplementedException();
        }

        protected abstract TEntity OnCreateEntityFromObject(TObject tObject);

        protected abstract TObject OnCreateObjectFromEntity(TEntity entity);

        public object ConvertObjectToEntity(object value) {
            if(value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            if (!(value is TObject tObject)) {
                throw new InvalidCastException($"{value} is not a instance of {typeof(TObject)}.");
            }

            return ConvertObjectToEntity(tObject);
        }

        public object ConvertEntityToObject(object entity) {
            if(entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }

            if(!(entity is TEntity tEntity)) {
                throw new InvalidCastException($"{entity} is not a instance of {typeof(TEntity)}.");
            }

            return ConvertEntityToObject(tEntity);
        }
    }

    
}
