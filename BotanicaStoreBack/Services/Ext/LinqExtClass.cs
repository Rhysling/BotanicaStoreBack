using System;
using System.Collections.Generic;
using System.Linq;

namespace BotanicaStoreBack.Services.LinqExt;

public static class LinqExtClass
{
	public static IList<TR> FullOuterGroupJoin<TA, TB, TK, TR>(
		this IEnumerable<TA> a,
		IEnumerable<TB> b,
		Func<TA, TK> selectKeyA,
		Func<TB, TK> selectKeyB,
		Func<IEnumerable<TA>, IEnumerable<TB>, TK, TR> projection,
		IEqualityComparer<TK> cmp = null)
	{
		cmp = cmp ?? EqualityComparer<TK>.Default;
		var alookup = a.ToLookup(selectKeyA, cmp);
		var blookup = b.ToLookup(selectKeyB, cmp);

		var keys = new HashSet<TK>(alookup.Select(p => p.Key), cmp);
		keys.UnionWith(blookup.Select(p => p.Key));

		var join = from key in keys
								let xa = alookup[key]
								let xb = blookup[key]
								select projection(xa, xb, key);

		return join.ToList();
	}

	public static IList<TR> FullOuterJoin<TA, TB, TK, TR>(
		this IEnumerable<TA> a,
		IEnumerable<TB> b,
		Func<TA, TK> selectKeyA,
		Func<TB, TK> selectKeyB,
		Func<TA, TB, TK, TR> projection,
		TA defaultA = default(TA),
		TB defaultB = default(TB),
		IEqualityComparer<TK> cmp = null)
	{
		cmp = cmp ?? EqualityComparer<TK>.Default;
		var alookup = a.ToLookup(selectKeyA, cmp);
		var blookup = b.ToLookup(selectKeyB, cmp);

		var keys = new HashSet<TK>(alookup.Select(p => p.Key), cmp);
		keys.UnionWith(blookup.Select(p => p.Key));

		var join = from key in keys
								from xa in alookup[key].DefaultIfEmpty(defaultA)
								from xb in blookup[key].DefaultIfEmpty(defaultB)
								select projection(xa, xb, key);

		return join.ToList();
	}

	public static IList<TR> LeftOuterJoin<TA, TB, TK, TR>(
		this IEnumerable<TA> a,
		IEnumerable<TB> b,
		Func<TA, TK> selectKeyA,
		Func<TB, TK> selectKeyB,
		Func<TA, TB, TK, TR> projection,
		TB defaultB = default(TB),
		IEqualityComparer<TK> cmp = null)
	{
		cmp = cmp ?? EqualityComparer<TK>.Default;
		var alookup = a.ToLookup(selectKeyA, cmp);
		var blookup = b.ToLookup(selectKeyB, cmp);

		var keys = new HashSet<TK>(alookup.Select(p => p.Key), cmp);

		var join = from key in keys
								from xa in alookup[key]
								from xb in blookup[key].DefaultIfEmpty(defaultB)
								select projection(xa, xb, key);

		return join.ToList();
	}

}