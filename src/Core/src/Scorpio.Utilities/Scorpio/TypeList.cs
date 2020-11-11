﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
namespace Scorpio
{
    /// <summary>
    /// A shortcut for <see cref="TypeList{TBaseType}"/> to use object as base type.
    /// </summary>
    public class TypeList : TypeList<object>, ITypeList
    {
    }

    /// <summary>
    /// Extends <see cref="List{Type}"/> to add restriction a specific base type.
    /// </summary>
    /// <typeparam name="TBaseType">Base Type of <see cref="Type"/>s in this list</typeparam>
    public class TypeList<TBaseType> : ITypeList<TBaseType>
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count => _typeList.Count;

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the <see cref="Type"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public Type this[int index]
        {
            get => _typeList[index];
            set
            {
                CheckType(value);
                _typeList[index] = value;
            }
        }

        private readonly List<Type> _typeList;

        /// <summary>
        /// Creates a new <see cref="TypeList{T}"/> object.
        /// </summary>
        public TypeList() => _typeList = new List<Type>();


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Add<T>() where T : TBaseType => _typeList.Add(typeof(T));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(Type item)
        {
            CheckType(item);
            _typeList.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public bool TryAdd<T>() where T : TBaseType
        {
            if (Contains<T>())
            {
                return false;
            }

            Add<T>();
            return true;
        }


        /// <inheritdoc/>
        public void Insert(int index, Type item)
        {
            CheckType(item);
            _typeList.Insert(index, item);
        }

        /// <inheritdoc/>
        public int IndexOf(Type item)
        {
            CheckType(item);
            return _typeList.IndexOf(item);
        }

        /// <inheritdoc/>
        public bool Contains<T>() where T : TBaseType => Contains(typeof(T));

        /// <inheritdoc/>
        public bool Contains(Type item)
        {
            CheckType(item);
            return _typeList.Contains(item);
        }

        /// <inheritdoc/>
        public bool Remove<T>() where T : TBaseType => _typeList.Remove(typeof(T));

        /// <inheritdoc/>
        public bool Remove(Type item)
        {
            CheckType(item);
            return _typeList.Remove(item);
        }

        /// <inheritdoc/>
        public void RemoveAt(int index) => _typeList.RemoveAt(index);

        /// <inheritdoc/>
        public void Clear() => _typeList.Clear();

        /// <inheritdoc/>
        public void CopyTo(Type[] array, int arrayIndex) => _typeList.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public IEnumerator<Type> GetEnumerator() => _typeList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _typeList.GetEnumerator();

        private static void CheckType(Type item)
        {
            Check.NotNull(item, nameof(item));
            if (!typeof(TBaseType).GetTypeInfo().IsAssignableFrom(item))
            {
                throw new ArgumentException($"Given type ({item.AssemblyQualifiedName}) should be instance of {typeof(TBaseType).AssemblyQualifiedName} ", nameof(item));
            }
        }
    }
}
