using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.Common.Helper
{
    public class MapperHelper
    {
        /// <summary>
        /// Mapper.Map转换
        /// </summary>
        /// <typeparam name="DtoEntity"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DtoEntity ResultData<DtoEntity, TEntity>(TEntity entity)
        {
            var dto = Mapper.Map<DtoEntity>(entity);
            return dto;
        }
    }
}
