### Iterator Pattern

1. There is a collection implementing `IEnumerable` interface. From collection might be known is there any items more, and get current item.
2. There is an entity called `Enumerator: IEnumerator`, it takes a collection as parameter and contains only two methods `bool HasNext()` and `T Next()`.
3. Moreover collection which implements an `IEnumerable` interface contains a factory `IEnumerator GetEnumerator()` which returns `new Enumerator(this)` of current collection.

### Useful links

https://metanit.com/sharp/patterns/3.5.php