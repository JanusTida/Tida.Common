using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDO.Common.Core.Util {
    /// <summary>
    /// 类-类转化器基类,旨在减少检查参数的重复性代码;
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ClassClassConverter<TObject, TEntity> : IObjectEntityConverter<TObject, TEntity> where TObject:class where TEntity:class{
        public Type ObjectType => typeof(TObject);

        public Type EntityType => typeof(TEntity);

        object IObjectEntityConverter.ConvertEntityToObject(object value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            if (!(value is TEntity entity)) {
                throw new InvalidCastException($"{value} is not a instance of {typeof(TEntity)}.");
            }

            return ConvertEntityToObject(entity);
        }


        object IObjectEntityConverter.ConvertObjectToEntity(object value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            if (!(value is TObject tObject)) {
                throw new InvalidCastException($"{value} is not a instance of {typeof(TObject)}.");
            }
            
            return ConvertObjectToEntity(tObject);
        }

        public TEntity ConvertObjectToEntity(TObject tObject) {
            if(tObject == null) {
                throw new ArgumentNullException(nameof(tObject));
            }

            return OnCreateEntityFromObject(tObject);
        }
        
        public TObject ConvertEntityToObject(TEntity entity) {
            if(entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }

            return OnCreateObjectFromEntity(entity);
        }

        public object CreateObjectToEntity(object tObject) {
            throw new NotImplementedException();
        }

        protected abstract TEntity OnCreateEntityFromObject(TObject tObject);

        protected abstract TObject OnCreateObjectFromEntity(TEntity entity);
    }
}
