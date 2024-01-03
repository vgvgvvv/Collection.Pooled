using System;
using System.Buffers;
using System.Threading;

namespace Collections.Pooled
{
    /// <summary>
    /// array pool provider
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArrayPoolSource<T>
    {
        T[] Rent(int size);

        void Return(T[] array, bool clearArray = false);
    }

    /// <summary>
    /// default implement, behave same with ArrayPool, thread safe by lock pool
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DefaultArrayPoolSource<T> : IArrayPoolSource<T>
    {
        private DefaultArrayPoolSource(ArrayPool<T>? source = null)
        {
            _pool = source ?? SharedPool;
        }

        public static IArrayPoolSource<T> Create(ArrayPool<T>? source = null)
        {
            if (source == null || source == SharedPool)
            {
                return Shared;
            }

            return new DefaultArrayPoolSource<T>(source);
        }
        
        public T[] Rent(int size)
        {
            lock (_pool)
            {
                return _pool.Rent(size);
            }
        }

        public void Return(T[] array, bool clearArray = false)
        {
            lock (_pool)
            {
                _pool.Return(array, clearArray);
            }
        }

        private readonly ArrayPool<T> _pool;

        public static ArrayPool<T> SharedPool { get; } = ArrayPool<T>.Create();
        public static DefaultArrayPoolSource<T> Shared { get; }= new DefaultArrayPoolSource<T>(SharedPool);
    }

    /// <summary>
    /// thread safe by lock thread local
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThreadLocalArrayPoolSource<T> : IArrayPoolSource<T>
    {
        private ThreadLocalArrayPoolSource(Func<ArrayPool<T>>? creator = null)
        {
            _threadLocalPool = new ThreadLocal<ArrayPool<T>>(creator ?? ArrayPool<T>.Create);
        }

        public static IArrayPoolSource<T> Create(Func<ArrayPool<T>>? creator = null)
        {
            if (creator == null || creator == ArrayPool<T>.Create)
            {
                return Shared;
            }
            return new ThreadLocalArrayPoolSource<T>(creator);
        }
        
        public T[] Rent(int size)
        {
            return _threadLocalPool.Value.Rent(size);
        }

        public void Return(T[] array, bool clearArray = false)
        {
            _threadLocalPool.Value.Return(array, clearArray);
        }

        private readonly ThreadLocal<ArrayPool<T>> _threadLocalPool = null;
        
        public static ThreadLocalArrayPoolSource<T> Shared { get; }= new ThreadLocalArrayPoolSource<T>(ArrayPool<T>.Create);
    }
}