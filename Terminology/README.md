## Computer Science Terminology

- **API** - Application Programming Interface. 

- **Implicit declaration** - initialization of the variable of the implicit typization, eg. 
  - `var t = 10;` 
  - `var u = "string"`
  - `var v = new Instance()`
  
  Note that class members cannot be assigned using implicit declaration.
  
- **Explicit declataion** - initialization of the entity in explicit way, so its type is clearly seen, eg.
  - `int t = 10`
  - `string u = "string"`
  - `Instance v = new Instance()`
  
  Class members can be assigned only using explisit typization.

- **Boxing** - is convertation of `value` type to `reference` type.

- **Unboxing** - is convertation of `reference` type to `value` type. Inverse to Boxing.

- **Boxing-Unboxing Examples**

```cs	
int i = 123;
object o = i;	// object – is reference type, int - is value type, so here is boxing done
int j = (int)o;		// here we unbox object o, eg. convert object (reference) to int (value).
```

- **Operator ?** - is `ternary operator`. Short definition of switch case. Works as follows

```cs
var t = (condition) ? condition is true : condition is false;

int x = 10;
int y = (x > 5) ? x : 10;	// assignes y = x, since x = 10 > 5.
```

- **Operator ??** - is `null-coalescing operator`. Not to be confused with ternaty operator. Works as follows

```cs
int? t = null;
		
int y = x ?? -1;		// if x is null - assignes -1 to y, else assignes y = x
```
		
- **Checked-Unchecked clause** - Opens a posibility to skip compiler's errors or force check. For example

```cs
unchecked
{
	int int1 = 2147483647 + 10;		// compiler - OK
}

int int2 = 2147483647 + 10;		// compiler - Error
```
		
- **throw(ex) vs throw**

  - `throw(ex);` - clears all exception history, showing only the line where exception thrown.
  
  - `throw;` - keeps all exception history. More convenient to use `throw;`.
  
OFFSET	
0,5

COMMENTS	
C(n,k) = number of k-element subsets of an n-element set.

Row n gives coefficients in expansion of (1+x)^n.

Binomial(n+k-1,n-1) is the number of ways of placing k indistinguishable balls into n boxes (the "bars and stars" argument - see Feller).

Binomial(n-1,k-1) is the number of compositions (ordered partitions) of n with k summands.

Binomial(n+k-1,k-1) is the number of weak compositions (ordered weak partitions) of n into exactly k summands. - Juergen Will, Jan 23 2016

Binomial(n,k) is the number of lattice paths from (0,0) to (n,k) using steps (1,0) and (1,1). - Joerg Arndt, Jul 01 2011

If thought of as an infinite lower triangular matrix, inverse begins:

  +1

  -1 +1

  +1 -2 +1

  -1 +3 -3 +1

  +1 -4 +6 -4 +1

All 2^n palindromic binomial coefficients starting after the A006516(n)-th entry are odd. - Lekraj Beedassy, May 20 2003

Binomial(n+k-1,n-1) is the number of standard tableaux of shape (n,1^k). - Emeric Deutsch, May 13 2004

Can be viewed as an array, read by antidiagonals, where the entries in the first row and column are all 1's and A(i,j) = A(i-1,j) + A(i,j-1) for all other entries. The determinant of each of its n X n subarrays starting at (0,0) is 1. - Gerald McGarvey, Aug 17 2004

Also the lower triangular readout of the exponential of a matrix whose entry {j+1,j} equals j+1 (and all other entries are zero). - Joseph Biberstine (jrbibers(AT)indiana.edu), May 26 2006

Binomial(n-3,k-1) counts the permutations in S_n which have zero occurrences of the pattern 231 and one occurrence of the pattern 132 and k descents. Binomial(n-3,k-1) also counts the permutations in S_n which have zero occurrences of the pattern 231 and one occurrence of the pattern 213 and k descents. - David Hoek (david.hok(AT)telia.com), Feb 28 2007

Inverse of A130595 (as an infinite lower triangular matrix). - Philippe Deléham, Aug 21 2007

Consider integer lists LL of lists L of the form LL = [m#L] = [m#[k#2]] (where '#' means 'times') like LL(m=3,k=3) = [[2,2,2],[2,2,2],[2,2,2]]. The number of the integer list partitions of LL(m,k) is equal to binomial(m+k,k) if multiple partitions like [[1,1],[2],[2]] and [[2],[2],[1,1]] and [[2],[1,1],[2]] are counted only once. For the example, we find 4*5*6/3! = 20 = binomial(6,3). - Thomas Wieder, Oct 03 2007

The infinitesimal generator for Pascal's triangle and its inverse is A132440. - Tom Copeland, Nov 15 2007

Row n>=2 gives the number of k-digit (k>0) base n numbers with strictly decreasing digits; e.g., row 10 for A009995. Similarly, row n-1>=2 gives the number of k-digit (k>1) base n numbers with strictly increasing digits; see A009993 and compare A118629. - Rick L. Shepherd, Nov 25 2007

From Lee Naish (lee(AT)cs.mu.oz.au), Mar 07 2008: (Start)

Binomial(n+k-1, k) is the number of ways a sequence of length k can be partitioned into n subsequences (see the Naish link).

Binomial(n+k-1, k) is also the number of n- (or fewer) digit numbers written in radix at least k whose digits sum to k. For example, in decimal, there are binomial(3+3-1,3)=10 3-digit numbers whose digits sum to 3 (see A052217) and also binomial(4+2-1,2)=10 4-digit numbers whose digits sum to 2 (see A052216). This relationship can be used to generate the numbers of sequences A052216 to A052224 (and further sequences using radix greater than 10). (End)

From Milan Janjic, May 07 2008: (Start)

Denote by sigma_k(x_1,x_2,...,x_n) the elementary symmetric polynomials. Then:

Binomial(2n+1,2k+1) = sigma_{n-k}(x_1,x_2,...,x_n), where x_i = tan^2(i*Pi/(2n+1)), (i=1,2,...,n).

Binomial(2n,2k+1) = 2n*sigma_{n-1-k}(x_1,x_2,...,x_{n-1}), where x_i = tan^2(i*Pi/(2n)), (i=1,2,...,n-1).

Binomial(2n,2k) = sigma_{n-k}(x_1,x_2,...,x_n), where x_i = tan^2((2i-1)Pi/(4n)), (i=1,2,...,n).

Binomial(2n+1,2k) = (2n+1)sigma_{n-k}(x_1,x_2,...,x_n), where x_i = tan^2((2i-1)Pi/(4n+2)), (i=1,2,...,n). (End)

Given matrices R and S with R(n,k) = binomial(n,k)*r(n-k) and S(n,k) = binomial(n,k)*s(n-k), then R*S = T where T(n,k) = binomial(n,k)*[r(.)+s(.)]^(n-k), umbrally. And, the e.g.f.s for the row polynomials of R, S and T are, respectively, exp(x*t)*exp[r(.)*x], exp(x*t)*exp[s(.)*x] and exp(x*t)*exp[r(.)*x]*exp[s(.)*x] = exp{[t+r(.)+s(.)]*x}. The row polynomials are essentially Appell polynomials. See A132382 for an example. - Tom Copeland, Aug 21 2008

As the rectangle R(m,n) = binomial(m+n-2,m-1), the weight array W (defined generally at A144112) of R is essentially R itself, in the sense that if row 1 and column 1 of W=A144225 are deleted, the remaining array is R. - Clark Kimberling, Sep 15 2008

If A007318 = M as an infinite lower triangular matrix, M^n gives A130595, A023531, A007318, A038207, A027465, A038231, A038243, A038255, A027466, A038279, A038291, A038303, A038315, A038327, A133371, A147716, A027467 for n=-1,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15 respectively. - Philippe Deléham, Nov 11 2008

The coefficients of the polynomials with e.g.f. exp(x*t)*(cosh(t)+sinh(t)). - Peter Luschny, Jul 09 2009

The triangle or chess sums, see A180662 for their definitions, link Pascal's triangle with twenty different sequences, see the crossrefs. All sums come in pairs due to the symmetrical nature of this triangle. The knight sums Kn14 - Kn110 have been added. It is remarkable that all knight sums are related to the Fibonacci numbers, i.e., A000045, but none of the others. - Johannes W. Meijer, Sep 22 2010

Binomial(n,k) is also the number of ways to distribute n+1 balls into k+1 urns so that each urn gets at least one ball. See example in the example section below. - Dennis P. Walsh, Jan 29 2011

Binomial(n,k) is the number of increasing functions from {1,...,k} to {1,...,n} since there are binomial(n,k) ways to choose the k distinct, ordered elements of the range from the codomain {1,...,n}. See example in the example section below. - Dennis P. Walsh, Apr 07 2011

Central binomial coefficients: T(2*n,n) = A000984(n), T(n, floor(n/2)) = A001405(n). - Reinhard Zumkeller, Nov 09 2011

Binomial(n,k) is the number of subsets of {1,...,n+1} with k+1 as median element. To see this, note that Sum_{j=0..min(k,n-k)}binomial(k,j)*binomial(n-k,j) = binomial(n,k). See example in Example section below. - Dennis P. Walsh, Dec 15 2011

This is the coordinator triangle for the lattice Z^n, see Conway-Sloane, 1997. - N. J. A. Sloane, Jan 17 2012

One of three infinite families of integral factorial ratio sequences of height 1 (see Bober, Theorem 1.2). The other two are A046521 and A068555. For real r >= 0, C_r(n,k) := floor(r*n)!/(floor(r*k)!*floor(r*(n-k))!) is integral. See A211226 for the case r = 1/2. - Peter Bala, Apr 10 2012

For n > 0: T(n,k) = A029600(n,k) - A029635(n,k), 0 <= k <= n. - Reinhard Zumkeller, Apr 16 2012

Define a finite triangle T(m,k) with n rows such that T(m,0) = 1 is the left column, T(m,m) = binomial(n-1,m) is the right column, and the other entries are T(m,k) = T(m-1,k-1) + T(m-1,k) as in Pascal's triangle. The sum of all entries in T (there are A000217(n) elements) is 3^(n-1). - J. M. Bergot, Oct 01 2012

The lower triangular Pascal matrix serves as a representation of the operator exp(RLR) in a basis composed of a sequence of polynomials p_n(x) characterized by ladder operators defined by R p_n(x) = p_(n+1)(x) and L p_n(x) = n p_(n-1)(x). See A132440, A218272, A218234, A097805, and A038207. The transposed and padded Pascal matrices can be associated to the special linear group SL2. - Tom Copeland, Oct 25 2012

See A193242. - Alexander R. Povolotsky, Feb 05 2013

A permutation p_1...p_n of the set {1,...,n} has a descent at position i if p_i > p_(i+1). Let S(n) denote the subset of permutations p_1...p_n of {1,...,n} such that p_(i+1) - p_i <= 1 for i = 1,...,n-1. Then binomial(n,k) gives the number of permutations in S(n+1) with k descents. Alternatively, binomial(n,k) gives the number of permutations in S(n+1) with k+1 increasing runs. - Peter Bala, Mar 24 2013

Sum_{n=>0} binomial(n,k)/n!) = e/k!, where e = exp(1), while allowing n < k where binomial(n,k) = 0. Also Sum_{n>=0} binomial(n+k-1,k)/n! = e * A000262(k)/k!, and for k>=1 equals e * A067764(k)/A067653(k). - Richard R. Forberg, Jan 01 2014

The square n X n submatrix (first n rows and n columns) of the Pascal matrix P(x) defined in the formulas below when multiplying on the left the Vandermonde matrix V(x_1,...,x_n) (with ones in the first row) translates the matrix to V(x_1+x,...,x_n+x) while leaving the determinant invariant. - Tom Copeland, May 19 2014

For k>=2, n>=k,  k/((k/(k-1) - Sum_{n=k..m} 1/binomial(n,k))) = m!/((m-k+1)!*(k-2)!). Note: k/(k-1) is the infinite sum. See A000217, A000292, A000332 for examples. - Richard R. Forberg, Aug 12 2014

Let G_(2n) be the subgroup of the symmetric group S_(2n) defined by G_(2n) = {p in S_(2n) | p(i) = i (mod n) for i = 1,2,...,2n}. G_(2n) has order 2^n. Binomial(n,k) gives the number of permutations in G_(2n) having n + k cycles. Cf. A130534 and A246117. - Peter Bala, Aug 15 2014

T(n,k) = A245334(n,k) / A137948(n,k), 0 <= k <= n. - Reinhard Zumkeller, Aug 31 2014

C(n,k) = the number of Dyck paths of semilength n+1, with k+1 "u"'s in odd numbered positions and k+1 returns to the x axis. Example: {U = u in odd position and _ = return to x axis} binomial(3,0)=1 (Uudududd_); binomial(3,1)=3 [(Uududd_Ud_), (Ud_Uududd_), (Uudd_Uudd_)]; binomial(3,2)=3 [(Ud_Ud_Uudd_), (Uudd_Ud_Ud_), (Ud_Uudd_Ud_)]; binomial(3,3)=1 (Ud_Ud_Ud_Ud_). - Roger Ford, Nov 05 2014

From Daniel Forgues, Mar 12 2015: (Start)

The binomial coefficients binomial(n,k) give the number of individuals of the k-th generation after n population doublings. For each doubling of population, each individual's clone has its generation index incremented by 1, and thus goes to the next row. Just tally up each row from 0 to 2^n - 1 to get the binomial coefficients.

       0   1       3               7                              15

    0: O | . | .   . | .   .   .   . | .   .   .   .   .   .   .   . |

    1:   | O | O   . | O   .   .   . | O   .   .   .   .   .   .   . |

    2:   |   |     O |     O   O   . |     O   O   .   O   .   .   . |

    3:   |   |       |             O |             O       O   O   . |

    4:   |   |       |               |                             O |

This is a fractal process: to get the pattern from 0 to 2^n - 1, append a shifted down (by one row) copy of the pattern from 0 to 2^(n-1) - 1 to the right of the pattern from 0 to 2^(n-1) - 1. (Inspired by the "binomial heap" data structure.)

Sequence of generation indices: 1's-counting sequence: number of 1's in binary expansion of n (or the binary weight of n) (see A000120):

  {0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4, ...}

Binary expansion of 0 to 15:

  0   1   10   11  100  101  110  111 1000 1001 1010 1011 1100 1101 1111

(End)

A258993(n,k) = T(n+k,n-k), n > 0. - Reinhard Zumkeller, Jun 22 2015

T(n,k) is the number of set partitions w of [n+1] that avoid 1/2/3 with rb(w)=k. The same holds for ls(w)=k, where avoidance is in the sense of Klazar and ls,rb defined by Wachs and White.

Satisfies Benford's law [Diaconis, 1977] - N. J. A. Sloane, Feb 09 2017

Let {A(n)} be a set with exactly n identical elements, with {A(0)} being the empty set E. Let {A(n,k)} be the k-th iteration of {A(n)}, with {A(n,0)} = {A(n)}. {A(n,1)} = The set of all the subsets of A{(n)}, including {A(n)} and E. {A(n,k)} = The set of all subsets of {A(n,k-1)}, including all of the elements of {A(n,k-1)}. Let A(n,k) be the number of elements in {A(n,k)}. Then A(n,k) = C(n+k,k), with each successive iteration replicating the members of the k-th diagonal of Pascal's Triangle. See examples. - Gregory L. Simay, Aug 06 2018

Binomial(n-1,k) is also the number of permutations avoiding both 213 and 312 with k ascents. - Lara Pudwell, Dec 19 2018

Binomial(n-1,k) is also the number of permutations avoiding both 132 and 213 with k ascents. - Lara Pudwell, Dec 19 2018

Binomial(n,k) is the dimension of the k-th exterior power of a vector space of dimension n. - Stefano Spezia, Dec 22 2018

REFERENCES	
M. Abramowitz and I. A. Stegun, eds., Handbook of Mathematical Functions, National Bureau of Standards Applied Math. Series 55, 1964 (and various reprintings), p. 828.

A. T. Benjamin and J. J. Quinn, Proofs that really count: the art of combinatorial proof, M.A.A. 2003, p. 63ff.

B. A. Bondarenko, Generalized Pascal Triangles and Pyramids (in Russian), FAN, Tashkent, 1990, ISBN 5-648-00738-8.

L. Comtet, Advanced Combinatorics, Reidel, 1974, p. 306.

P. Curtz, Intégration numérique des systèmes différentiels à conditions initiales, Centre de Calcul Scientifique de l'Armement, Arcueil, 1969.

W. Feller, An Introduction to Probability Theory and Its Application, Vol. 1, 2nd ed. New York: Wiley, p. 36, 1968.

R. L. Graham, D. E. Knuth and O. Patashnik, Concrete Mathematics. Addison-Wesley, Reading, MA, 2nd. ed., 1994, p. 155.

D. Hök, Parvisa mönster i permutationer [Swedish], 2007.

D. E. Knuth, The Art of Computer Programming, Vol. 1, 2nd ed., p. 52.

S. K. Lando, Lecture on Generating Functions, Amer. Math. Soc., Providence, R.I., 2003, pp. 60-61.

Merlini, D., Sprugnoli, R., & Verri, M. C. (2000). An algebra for proper generating trees. In Mathematics and Computer Science (pp. 127-139). Birkhäuser, Basel.

Clifford A. Pickover, A Passion for Mathematics, Wiley, 2005; see p. 71.

A. P. Prudnikov, Yu. A. Brychkov and O. I. Marichev, "Integrals and Series", Volume 1: "Elementary Functions", Chapter 4: "Finite Sums", New York, Gordon and Breach Science Publishers, 1986-1992.

J. Riordan, An Introduction to Combinatorial Analysis, Wiley, 1958, p. 6.

J. Riordan, Combinatorial Identities, Wiley, 1968, p. 2.

R. Sedgewick and P. Flajolet, An Introduction to the Analysis of Algorithms, Addison-Wesley, Reading, MA, 1996, p. 143.

N. J. A. Sloane and Simon Plouffe, The Encyclopedia of Integer Sequences, Academic Press, 1995 (includes this sequence).

D. Wells, The Penguin Dictionary of Curious and Interesting Numbers, pp. 115-8, Penguin Books 1987.

LINKS	
N. J. A. Sloane, First 141 rows of Pascal's triangle, formatted as a simple linear sequence: (n, a(n)), n=0..10152.

M. Abramowitz and I. A. Stegun, eds., Handbook of Mathematical Functions, National Bureau of Standards, Applied Math. Series 55, Tenth Printing, 1972 [alternative scanned copy].

Tewodros Amdeberhan, Moa Apagodu, Doron Zeilberger, Wilf's "Snake Oil" Method Proves an Identity in The Motzkin Triangle, arXiv:1507.07660 [math.CO], 2015.

S. V. Ault and C. Kicey, Counting paths in corridors using circular Pascal arrays, Discrete Mathematics (2014).

Mohammad K. Azarian, Fibonacci Identities as Binomial Sums, International Journal of Contemporary Mathematical Sciences, Vol. 7, No. 38, 2012, pp. 1871-1876.

Mohammad K. Azarian, Fibonacci Identities as Binomial Sums II, International Journal of Contemporary Mathematical Sciences, Vol. 7, No. 42, 2012, pp. 2053-2059.

Armen G. Bagdasaryan, Ovidiu Bagdasar, On some results concerning generalized arithmetic triangles, Electronic Notes in Discrete Mathematics (2018) Vol. 67, 71-77.

Peter Bala, A combinatorial interpretation for the binomial coefficients

C. Banderier and D. Merlini, Lattice paths with an infinite set of jumps

J. Fernando Barbero G., Jesús Salas, Eduardo J. S. Villaseñor, Bivariate Generating Functions for a Class of Linear Recurrences. I. General Structure, arXiv:1307.2010 [math.CO], 2013.

Paul Barry, On Integer-Sequence-Based Constructions of Generalized Pascal Triangles, Journal of Integer Sequences, Vol. 9 (2006), Article 06.2.4.

Paul Barry, Symmetric Third-Order Recurring Sequences, Chebyshev Polynomials, and Riordan Arrays , JIS 12 (2009) 09.8.6.

Paul Barry, Eulerian polynomials as moments, via exponential Riordan arrays, arXiv:1105.3043 [math.CO], 2011.

Paul Barry, Combinatorial polynomials as moments, Hankel transforms and exponential Riordan arrays, arXiv:1105.3044 [math.CO], 2011.

P. Barry, On the Central Coefficients of Bell Matrices, J. Int. Seq. 14 (2011) # 11.4.3. example 2.

Paul Barry, Riordan-Bernstein Polynomials, Hankel Transforms and Somos Sequences, Journal of Integer Sequences, Vol. 15 2012, #12.8.2.

Paul Barry, On the Central Coefficients of Riordan Matrices, Journal of Integer Sequences, 16 (2013), #13.5.1.

Paul Barry, A Note on a Family of Generalized Pascal Matrices Defined by Riordan Arrays, Journal of Integer Sequences, 16 (2013), #13.5.4.

Paul Barry, On the Inverses of a Family of Pascal-Like Matrices Defined by Riordan Arrays, Journal of Integer Sequences, 16 (2013), #13.5.6.

Paul Barry, On the Connection Coefficients of the Chebyshev-Boubaker polynomials, The Scientific World Journal, Volume 2013 (2013), Article ID 657806, 10 pages.

Paul Barry, General Eulerian Polynomials as Moments Using Exponential Riordan Arrays, Journal of Integer Sequences, 16 (2013), #13.9.6.

Paul Barry, Riordan arrays, generalized Narayana triangles, and series reversion, Linear Algebra and its Applications, 491 (2016) 343-385.

Paul Barry, The Gamma-Vectors of Pascal-like Triangles Defined by Riordan Arrays, arXiv:1804.05027 [math.CO], 2018.

Paul Barry, On the f-Matrices of Pascal-like Triangles Defined by Riordan Arrays, arXiv:1805.02274 [math.CO], 2018.

Paul Barry, The Central Coefficients of a Family of Pascal-like Triangles and Colored Lattice Paths, J. Int. Seq., Vol. 22 (2019), Article 19.1.3.

Paul Barry, On the halves of a Riordan array and their antecedents, arXiv:1906.06373 [math.CO], 2019.

Paul Barry, On the r-shifted central triangles of a Riordan array, arXiv:1906.01328 [math.CO], 2019.

Paul Barry, Generalized Catalan Numbers Associated with a Family of Pascal-like Triangles, J. Int. Seq., Vol. 22 (2019), Article 19.5.8.

Paul Barry, A Note on Riordan Arrays with Catalan Halves, arXiv:1912.01124 [math.CO], 2019.

Paul Barry, Chebyshev moments and Riordan involutions, arXiv:1912.11845 [math.CO], 2019.

P. Barry and A. Hennessy, Four-term Recurrences, Orthogonal Polynomials and Riordan Arrays, Journal of Integer Sequences, 2012, article 12.4.2.

J. W. Bober, Factorial ratios, hypergeometric series, and a family of step functions, arXiv:0709.1977v1 [math.NT], J. London Math. Soc. (2) 79 (2009), 422-444.

B. A. Bondarenko, Generalized Pascal Triangles and Pyramids, English translation published by Fibonacci Association, Santa Clara Univ., Santa Clara, CA, 1993; see p. 4.

M. Bukata, R. Kulwicki, N. Lewandowski, L. Pudwell, J. Roth, and T. Wheeland, Distributions of Statistics over Pattern-Avoiding Permutations, arXiv preprint arXiv:1812.07112 [math.CO], 2018.

D. Butler, Pascal's Triangle

Naiomi T. Cameron and Asamoah Nkwanta, On Some (Pseudo) Involutions in the Riordan Group, Journal of Integer Sequences, Vol. 8 (2005), Article 05.3.7.

Ji Young Choi, Digit Sums Generalizing Binomial Coefficients, J. Int. Seq., Vol. 22 (2019), Article 19.8.3.

C. Cobeli and A. Zaharescu, Promenade around Pascal Triangle - Number Motives, Bull. Math. Soc. Sci. Math. Roumanie, Tome 56(104) No. 1, 2013, 73-98.

CombOS - Combinatorial Object Server, Generate combinations

J. H. Conway and N. J. A. Sloane, Low-dimensional lattices. VII Coordination sequences, Proc. R. Soc. Lond. A (1997) 453, 2369-2389.

T. Copeland, Infinigens, the Pascal Triangle, and the Witt and Virasoro Algebras

Persi Diaconis, The distribution of leading digits and uniform distribution mod 1, Ann. Probability, 5, 1977, 72--81.

Tomislav Došlic, Darko Veljan, Logarithmic behavior of some combinatorial sequences, Discrete Math. 308 (2008), no. 11, 2182--2212. MR2404544 (2009j:05019).

S. Eger, Some Elementary Congruences for the Number of Weighted Integer Compositions, J. Int. Seq. 18 (2015) # 15.4.1.

L. Euler, On the expansion of the power of any polynomial (1+x+x^2+x^3+x^4+etc.)^n, arXiv:math/0505425 [math.HO], 2005. See also The Euler Archive, item E709.

Jackson Evoniuk, Steven Klee, Van Magnan, Enumerating Minimal Length Lattice Paths, J. Int. Seq., Vol. 21 (2018), Article 18.3.6.

A. Farina, et al., Tartaglia-Pascal's triangle: a historical perspective with applications, Signal, Image and Video Processing, January 2013, Volume 7, Issue 1, pp 173-188.

S. R. Finch, P. Sebah and Z.-Q. Bai, Odd Entries in Pascal's Trinomial Triangle, arXiv:0802.2654 [math.NT], 2008.

D. Fowler, The binomial coefficient function, Amer. Math. Monthly, 103 (1996), 1-17.

Shishuo Fu, Yaling Wang, Bijective recurrences concerning two Schröder triangles, arXiv:1908.03912 [math.CO], 2019.

Tom Halverson, Theodore N. Jacobson, Set-partition tableaux and representations of diagram algebras, arXiv:1808.08118 [math.RT], 2018.

Brady Haran and Casandra Monroe, Pascal's Triangle, Numberphile video (2017).

He, Tian-Xiao, and Sprugnoli, Renzo; Sequence characterization of Riordan arrays, Discrete Math. 309 (2009), no. 12, 3962-3974.

Nick Hobson, Python program for A007318

V. E. Hoggatt, Jr. and M. Bicknell, Catalan and related sequences arising from inverses of Pascal's triangle matrices, Fib. Quart., 14 (1976), 395-405.

Matthew Hubbard and Tom Roby, Pascal's Triangle From Top to Bottom [archived page]

Charles Jordan, Calculus of Finite Differences (p. 65).

S. Kak, The Golden Mean and the Physics of Aesthetics, arXiv:physics/0411195 [physics.hist-ph], 2004.

W. Lang, On generalizations of Stirling number triangles, J. Integer Seqs., Vol. 3 (2000), #00.2.4.

P. A. MacMahon, Memoir on the Theory of the Compositions of Numbers, Phil. Trans. Royal Soc. London A, 184 (1893), 835-901.

Mathforum, Pascal's Triangle

D. Merlini, F. Uncini and M. C. Verri, A unified approach to the study of general and palindromic compositions, Integers 4 (2004), A23, 26 pp.

Ângela Mestre, José Agapito, A Family of Riordan Group Automorphisms, J. Int. Seq., Vol. 22 (2019), Article 19.8.5.

Y. Moshe, The density of 0's in recurrence double sequences, J. Number Theory, 103 (2003), 109-121.

Lili Mu and Sai-nan Zheng, On the Total Positivity of Delannoy-Like Triangles, Journal of Integer Sequences, Vol. 20 (2017), Article 17.1.6.

A. Necer, Séries formelles et produit de Hadamard, Journal de théorie des nombres de Bordeaux, 9 no. 2 (1997), p. 319-335.

Asamoah Nkwanta and Earl R. Barnes, Two Catalan-type Riordan Arrays and their Connections to the Chebyshev Polynomials of the First Kind, Journal of Integer Sequences, Article 12.3.3, 2012.

A. Nkwanta, A. Tefera, Curious Relations and Identities Involving the Catalan Generating Function and Numbers, Journal of Integer Sequences, 16 (2013), #13.9.5.

M. A. A. Obaid, S. K. Nauman, W. M. Fakieh, C. M. Ringel, The numbers of support-tilting modules for a Dynkin algebra, 2014.

OEIS Wiki, Binomial coefficients

Richard L. Ollerton and Anthony G. Shannon, Some properties of generalized Pascal squares and triangles, Fib. Q., 36 (1998), 98-109.

Ed Pegg, Jr., Sequence Pictures, Math Games column, Dec 08 2003.

Ed Pegg, Jr., Sequence Pictures, Math Games column, Dec 08 2003 [Cached copy, with permission (pdf only)]

Kolosov Petro, Relation between Pascal's triangle and hypercubes, 2018.

Franck Ramaharo, Statistics on some classes of knot shadows, arXiv:1802.07701 [math.CO], 2018.

Franck Ramaharo, A generating polynomial for the pretzel knot, arXiv:1805.10680 [math.CO], 2018.

Franck Ramaharo, A generating polynomial for the two-bridge knot with Conway's notation C(n,r), arXiv:1902.08989 [math.CO], 2019.

T. M. Richardson, The Reciprocal Pascal Matrix, arXiv preprint arXiv:1405.6315 [math.CO], 2014.

L. W. Shapiro, S. Getu, W.-J. Woan and L. C. Woodson, The Riordan group, Discrete Applied Math., 34 (1991), 229-239.

N. J. A. Sloane, My favorite integer sequences, in Sequences and their Applications (Proceedings of SETA '98).

N. J. A. Sloane, Triangle showing silhouette of first 30 rows of Pascal's triangle (after Cobeli and Zaharescu)

Hermann Stamm-Wilbrandt, Compute C(n+m,...) based on C(n,...) and C(m,...) values animation

Ch. Stover and E. W. Weisstein, Composition. From MathWorld - A Wolfram Web Resource.

G. Villemin's Almanach of Numbers, Triangle de Pascal

Eric Weisstein's World of Mathematics, Pascal's Triangle

Wikipedia, Pascal's triangle

H. S. Wilf, Generatingfunctionology, 2nd edn., Academic Press, NY, 1994, pp. 12ff.

K. Williams, Mathforum, Interactive Pascal's Triangle

D. Zeilberger, The Combinatorial Astrology of Rabbi Abraham Ibn Ezra, arXiv:math/9809136 [math.CO], 1998.

Chris Zheng, Jeffrey Zheng, Triangular Numbers and Their Inherent Properties, Variant Construction from Theoretical Foundation to Applications, Springer, Singapore, 51-65.

Index entries for triangles and arrays related to Pascal's triangle

Index entries for "core" sequences

Index entries for sequences related to Benford's law

FORMULA	
a(n, k) = C(n,k) = binomial(n, k).

C(n, k) = C(n-1, k) + C(n-1, k-1).

The triangle is symmetric: C(n,k) = C(n,n-k).

a(n+1, m) = a(n, m) + a(n, m-1), a(n, -1) := 0, a(n, m) := 0, n<m; a(0, 0)=1.

C(n, k)=n!/(k!(n-k)!) if 0<=k<=n, otherwise 0.

G.f.: 1/(1-y-x*y) = Sum(C(n, k)*x^k*y^n, n, k>=0)

G.f.: 1/(1-x-y) = Sum(C(n+k, k)*x^k*y^n, n, k>=0).

G.f. for row n: (1+x)^n = Sum_{k=0..n} C(n, k)x^k.

G.f. for column n: x^n/(1-x)^n.

E.g.f.: A(x, y) = exp(x+x*y).

E.g.f. for column n: x^n*exp(x)/n!.

In general the m-th power of A007318 is given by: T(0, 0) = 1, T(n, k) = T(n-1, k-1) + m*T(n-1, k), where n is the row-index and k is the column; also T(n, k) = m^(n-k) C(n, k).

Triangle T(n, k) read by rows; given by A000007 DELTA A000007, where DELTA is Deléham's operator defined in A084938.

Let P(n+1) = the number of integer partitions of (n+1); let p(i) = the number of parts of the i-th partition of (n+1); let d(i) = the number of different parts of the i-th partition of (n+1); let m(i, j) = multiplicity of the j-th part of the i-th partition of (n+1). Define the operator Sum_{i=1..P(n+1), p(i)=k+1} as the sum running from i=1 to i=P(n+1) but taking only partitions with p(i)=(k+1) parts into account. Define the operator Product_{j=1..d(i)} = product running from j=1 to j=d(i). Then C(n, k) = Sum_{p(i)=(k+1), i=1..P(n+1)} p(i)! / [Product_{j=1..d(i)} m(i, j)!]. E.g., C(5, 3) = 10 because n=6 has the following partitions with m=3 parts: (114), (123), (222). For their multiplicities one has: (114): 3!/(2!*1!) = 3; (123): 3!/(1!*1!*1!) = 6; (222): 3!/3! = 1. The sum is 3 + 6 + 1 = 10 = C(5, 3). - Thomas Wieder, Jun 03 2005

C(n, k) = Sum_{j=0..k} = (-1)^j*C(n+1+j, k-j)*A000108(j). - Philippe Deléham, Oct 10 2005

G.f.: 1 + x(1 + x) + x^3(1 + x)^2 + x^6(1 + x)^3 + ... . - Michael Somos, Sep 16 2006

Sum_{k=0..floor(n/2)} x^(n-k)*T(n-k,k) = A000007(n), A000045(n+1), A002605(n), A030195(n+1), A057087(n), A057088(n), A057089(n), A057090(n), A057091(n), A057092(n), A057093(n) for x = 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, respectively. Sum_{k=0..floor(n/2)} (-1)^k*x^(n-k)*T(n-k,k) = A000007(n), A010892(n), A009545(n+1), A057083(n), A001787(n+1), A030191(n), A030192(n), A030240(n), A057084(n), A057085(n+1), A057086(n), A084329(n+1) for x = 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, respectively. - Philippe Deléham, Sep 16 2006

C(n,k) <= A062758(n) for n > 1. - Reinhard Zumkeller, Mar 04 2008

C(t+p-1, t) = Sum_{i=0..t} C(i+p-2, i) = Sum_{i=1..p} C(i+t-2, t-1). A binomial number is the sum of its left parent and all its right ancestors, which equals the sum of its right parent and all its left ancestors. - Lee Naish (lee(AT)cs.mu.oz.au), Mar 07 2008

From Paul D. Hanna, Mar 24 2011: (Start)

Let A(x) = Sum_{n>=0} x^(n(n+1)/2)*(1+x)^n be the g.f. of the flattened triangle:

A(x) = 1 + (x + x^2) + (x^3 + 2*x^4 + x^5) + (x^6 + 3*x^7 + 3*x^8 + x^9) +...

then A(x) equals the series Sum_{n>=0} (1+x)^n*x^n*Product_{k=1..n} (1-(1+x)*x^(2k-1))/(1-(1+x)*x^(2k));

also, A(x) equals the continued fraction 1/(1- x*(1+x)/(1+ x*(1-x)*(1+x)/(1- x^3*(1+x)/(1+ x^2*(1-x^2)*(1+x)/(1- x^5*(1+x)/(1+ x^3*(1-x^3)*(1+x)/(1- x^7*(1+x)/(1+ x^4*(1-x^4)*(1+x)/(1- ...))))))))).

These formulas are due to (1) a q-series identity and (2) a partial elliptic theta function expression. (End)

Row n of the triangle is the result of applying the ConvOffs transform to the first n terms of the natural numbers (1, 2, 3, ..., n). See A001263 or A214281 for a definition of this transformation. - Gary W. Adamson, Jul 12 2012

From L. Edson Jeffery, Aug 02 2012: (Start)

Row n (n >= 0) of the triangle is given by the n-th antidiagonal of the infinite matrix P^n, where P = (p_{i,j}), i,j >= 0, is the production matrix

0, 1,

1, 0, 1,

0, 1, 0, 1,

0, 0, 1, 0, 1,

0, 0, 0, 1, 0, 1,

0, 0, 0, 0, 1, 0, 1,

0, 0, 0, 0, 0, 1, 0, 1,

0, 0, 0, 0, 0, 0, 1, 0, 1,

... (End)

Row n of the triangle is also given by the n+1 coefficients of the polynomial P_n(x) defined by the recurrence P_0(x) = 1, P_1(x) = x + 1, P_n(x) = x*P_{n-1}(x) + P_{n-2}(x), n > 1. - L. Edson Jeffery, Aug 12 2013

For a closed-form formula for arbitrary left and right borders of Pascal-like triangles see A228196. - Boris Putievskiy, Aug 18 2013

For a closed-form formula for generalized Pascal's triangle see A228576. - Boris Putievskiy, Sep 04 2013

(1+x)^n = Sum_{k=0..n} (-1)^(n-k)*binomial(n,k)*Sum_{i=0..k} k^(n-i)*binomial(k,i)*x^(n-i)/(n-i)!. - Vladimir Kruchinin, Oct 21 2013

E.g.f.: A(x,y) = exp(x+x*y) = 1 + (x+y*x)/( E(0)-(x+y*x)), where E(k) = 1 + (x+y*x)/(1 + (k+1)/E(k+1) ); (continued fraction). - Sergei N. Gladkovskii, Nov 08 2013

E.g.f.:  E(0) -1, where E(k) = 2 + x*(1+y)/(2*k+1 - x*(1+y)/E(k+1) ); (continued fraction). - Sergei N. Gladkovskii, Dec 24 2013

G.f.: 1 + x*(1+x)*(1+x^2*(1+x)/(W(0)-x^2-x^3)), where W(k) = 1 + (1+x)*x^(k+2) - (1+x)*x^(k+3)/W(k+1); (continued fraction). - Sergei N. Gladkovskii, Dec 24 2013

Sum_{n>=0} C(n,k)/n! = e/k!, where e = exp(1), while allowing n < k where C(n,k) = 0. Also Sum_{n>=0} C(n+k-1,k)/n! = e * A000262(k)/k!, and for k>=1 equals e * A067764(k)/A067653(k). - Richard R. Forberg, Jan 01 2014

Sum_{n>=k} 1/C(n,k) = k/(k-1) for k>=1. - Richard R. Forberg, Feb 10 2014

From Tom Copeland, Apr 17 and 26 2014: (Start)

Multiply each n-th diagonal of the Pascal lower triangular matrix by x^n and designate the result by A007318(x) = P(x). Then with :xD:^n = x^n*(d/dx)^n and B(n,x), the Bell polynomials (A008277),

A) P(x)= exp(x*dP) = exp[x*(e^M-I)] = exp[M*B(.,x)] = (I+dP)^B(.,x)

   with dP = A132440, M = A238385-I, and I = identity matrix, and

B) P(:xD:) = exp(dP:xD:) = exp[(e^M-I):xD:] = exp[M*B(.,:xD:)] = exp[M*xD] = (I+dP)^(xD) with action P(:xD:)g(x) = exp(dP:xD:)g(x) = g[(I+dP)*x] (cf. also A238363).

C) P(x)^y = P(y*x). P(2x) = A038207(x) = exp[M*B(.,2x)], the face vectors of the n-dim hypercubes.

D) P(x) = [St2]*exp(x*M)*[St1] = [St2]*(I+dP)^x*[St1]

E) = [St1]^(-1)*(I+dP)^x*[St1] = [St2]*(I+dP)^x*[St2]^(-1)

where [St1]=padded A008275 just as [St2]=A048993=padded A008277 and exp(x*M) = (I+dP)^x = sum(k=0,..,infinity, C(x,k) dP^k). (End)

From Peter Bala, Dec 21 2014: (Start)

Recurrence equation: T(n,k) = T(n-1,k)*(n + k)/(n - k) - T(n-1,k-1) for n >= 2 and 1 <= k < n, with boundary conditions T(n,0) = T(n,n) = 1. Note, changing the minus sign in the recurrence to a plus sign gives a recurrence for the square of the binomial coefficients - see A008459.

There is a relation between the e.g.f.'s of the rows and the diagonals of the triangle, namely, exp(x) * e.g.f. for row n = e.g.f. for diagonal n. For example, for n = 3 we have exp(x)*(1 + 3*x + 3*x^2/2! + x^3/3!) = 1 + 4*x + 10*x^2/2! + 20*x^3/3! + 35*x^4/4! + .... This property holds more generally for the Riordan arrays of the form ( f(x), x/(1 - x) ), where f(x) is an o.g.f. of the form 1 + f_1*x + f_2*x^2 + .... See, for example, A055248 and A106516.

Let P denote the present triangle. For k = 0,1,2,... define P(k) to be the lower unit triangular block array

/I_k 0\

\ 0  P/ having the k X k identity matrix I_k as the upper left block; in particular, P(0) = P. The infinite product P(0)*P(1)*P(2)*..., which is clearly well-defined, is equal to the triangle of Stirling numbers of the second kind A008277. The infinite product in the reverse order, that is, ...*P(2)*P(1)*P(0), is equal to the triangle of Stirling cycle numbers A130534. (End)

C(a+b,c) = Sum_{k=0..a} C(a,k)*C(b,b-c+k). This is a generalization of equation 1 from section 4.2.5 of the Prudnikov et al. reference, for a=b=c=n: C(2n,n) = Sum_{k=0..n} C(n,k)^2. See Links section for animation of new formula. - Hermann Stamm-Wilbrandt, Aug 26 2015

The row polynomials of the Pascal matrix P(n,x) = (1+x)^n are related to the Bernoulli polynomials Br(n,x) and their umbral compositional inverses Bv(n,x) by the umbral relation P(n,x) = (-Br(.,-Bv(.,x)))^n = (-1)^n Br(n,-Bv(.,x)), which translates into the matrix relation P = M * Br * M * Bv, where P is the Pascal matrix, M is the diagonal matrix diag(1,-1,1,-1,...), Br is the matrix for the coefficients of the Bernoulli polynomials, and Bv that for the umbral inverse polynomials defined umbrally by Br(n,Bv(.,x)) = x^n = Bv(n,Br(.,x)). Note M = M^(-1). - Tom Copeland, Sep 05 2015

1/(1-x)^k = (r(x) * r(x^2) * r(x^4) * ...) where r(x) = (1+x)^k. - Gary W. Adamson, Oct 17 2016

Boas-Buck type recurrence for column k for Riordan arrays (see the Aug 10 2017 remark in A046521, also for the reference) with the Boas-Buck sequence b(n) = {repeat(1)}. T(n, k) = ((k+1)/(n-k))*Sum_{j=k..n-1} T(j, k), for n >= 1, with T(n, n) = 1. This reduces, with T(n, k) = binomial(n, k), to a known binomial identity (e.g, Graham et al. p. 161). - Wolfdieter Lang, Nov 12 2018

C((p-1)/a, b) == (-1)^b * fact_a(a*b-a+1)/fact_a(a*b) (mod p), where fact_n denotes the n-th multifactorial, a divides p-1, and the denominator of the fraction on the right side of the equation represents the modular inverse. - Isaac Saffold, Jan 07 2019

EXAMPLE	
Triangle T(n,k) begins:

   n\k 0   1   2   3   4   5   6   7   8   9  10  11...

   0   1

   1   1   1

   2   1   2   1

   3   1   3   3   1

   4   1   4   6   4   1

   5   1   5  10  10   5   1

   6   1   6  15  20  15   6   1

   7   1   7  21  35  35  21   7   1

   8   1   8  28  56  70  56  28   8   1

   9   1   9  36  84 126 126  84  36   9   1

  10   1  10  45 120 210 252 210 120  45  10   1

  11   1  11  55 165 330 462 462 330 165  55  11   1

  ...

There are C(4,2)=6 ways to distribute 5 balls BBBBB, among 3 different urns, < > ( ) [ ], so that each urn gets at least one ball, namely, <BBB>(B)[B], <B>(BBB)[B], <B>(B)[BBB], <BB>(BB)[B], <BB>(B)[BB], and <B>(BB)[BB].

There are C(4,2)=6 increasing functions from {1,2} to {1,2,3,4}, namely, {(1,1),(2,2)},{(1,1),(2,3)}, {(1,1),(2,4)}, {(1,2),(2,3)}, {(1,2),(2,4)}, and {(1,3),(2,4)}. - Dennis P. Walsh, Apr 07 2011

There are C(4,2)=6 subsets of {1,2,3,4,5} with median element 3, namely, {3}, {1,3,4}, {1,3,5}, {2,3,4}, {2,3,5}, and {1,2,3,4,5}. - Dennis P. Walsh, Dec 15 2011

The successive k-iterations of {A(0)} = E are E;E;E;...; the corresponding number of elements are 1,1,1,... The successive k-iterations of {A(1)} = {a} are (omitting brackets) a;a,E; a,E,E;...; the corresponding number of elements are 1,2,3,... The successive k-iterations of {A(2)} = {a,a} are aa; aa,a,E; aa, a, E and a,E and E;...; the corresponding number of elements are 1,3,6,... - Gregory L. Simay, Aug 06 2018

Boas-Buck type recurrence for column k = 4: T(8, 4) = (5/4)*(1 + 5 + 15 + 35) = 70. See the Boas-Buck comment above. - Wolfdieter Lang, Nov 12 2018

MAPLE	
A007318 := (n, k)->binomial(n, k);

MATHEMATICA	
Flatten[Table[Binomial[n, k], {n, 0, 11}, {k, 0, n}]] (* Robert G. Wilson v, Jan 19 2004 *)

Flatten[CoefficientList[CoefficientList[Series[1/(1 - x - x*y), {x, 0, 12}], x], y]] (* Mats Granvik, Jul 08 2014 *)

PROG	
(AXIOM) -- (start)

)set expose add constructor OutputForm

pascal(0, n) == 1

pascal(n, n) == 1

pascal(i, j | 0 < i and i < j) == pascal(i-1, j-1) + pascal(i, j-1)

pascalRow(n) == [pascal(i, n) for i in 0..n]

displayRow(n) == output center blankSeparate pascalRow(n)

for i in 0..20 repeat displayRow i -- (end)

(PARI) C(n, k)=binomial(n, k) \\ Charles R Greathouse IV, Jun 08 2011

(Python) See Hobson link. Further programs:

def C(n, k):

...if k<0 or k>n:

......return 0

...res=1

...for i in range(k):

......res=res*(n-i)//(i+1)

...return res

# Robert FERREOL, Mar 31 2018

def C(n, k): from numpy import prod; return prod([(n-j)/(j+1) for j in range(k)])

def C(n, k): from functools import reduce; return reduce(lambda x, y: x*(n-y)//(1+y), range(k), 1) # Some characters longer, but using only integers.

# M. F. Hasler, Dec 13 2019

(Haskell)

a007318 n k = a007318_tabl !! n !! k

a007318_row n = a007318_tabl !! n

a007318_list = concat a007318_tabl

a007318_tabl = iterate (\row -> zipWith (+) ([0] ++ row) (row ++ [0])) [1]

-- Cf. http://www.haskell.org/haskellwiki/Blow_your_mind#Mathematical_sequences

-- Reinhard Zumkeller, Nov 09 2011, Oct 22 2010

(Maxima) create_list(binomial(n, k), n, 0, 12, k, 0, n); /* Emanuele Munarini, Mar 11 2011 */

(Sage) def C(n, k): return Subsets(range(n), k).cardinality() # Ralf Stephan, Jan 21 2014

(MAGMA) /* As triangle: */ [[Binomial(n, k): k in [0..n]]: n in [0.. 10]]; // Vincenzo Librandi, Jul 29 2015

(GAP) Flat(List([0..12], n->List([0..n], k->Binomial(n, k)))); # Stefano Spezia, Dec 22 2018

CROSSREFS	
Equals differences between consecutive terms of A102363. - David G. Williams (davidwilliams(AT)Paxway.com), Jan 23 2006

Row sums give A000079 (powers of 2).

Cf. A083093 (triangle read mod 3), A214292 (first differences of rows).

Partial sums of rows give triangle A008949.

Infinite matrix squared: A038207, cubed: A027465.

Cf. A101164. If rows are sorted we get A061554 or A107430.

Another version: A108044.

Cf. A008277, A132311, A132312, A052216, A052217, A052218, A052219, A052220, A052221, A052222, A052223, A144225, A202750, A211226, A047999, A026729, A052553, A051920, A193242.

Triangle sums (see the comments): A000079 (Row1); A000007 (Row2); A000045 (Kn11 & Kn21); A000071 (Kn12 & Kn22); A001924 (Kn13 & Kn23); A014162 (Kn14 & Kn24); A014166 (Kn15 & Kn25); A053739 (Kn16 & Kn26); A053295 (Kn17 & Kn27); A053296 (Kn18 & Kn28); A053308 (Kn19 & Kn29); A053309 (Kn110 & Kn210); A001519 (Kn3 & Kn4); A011782 (Fi1 & Fi2); A000930 (Ca1 & Ca2); A052544 (Ca3 & Ca4); A003269 (Gi1 & Gi2); A055988 (Gi3 & Gi4); A034943 (Ze1 & Ze2); A005251 (Ze3 & Ze4). - Johannes W. Meijer, Sep 22 2010

Fibonacci-Pascal triangles: A027926, A036355, A037027, A074829, A105809, A109906, A111006, A114197, A162741, A228074, A228196, A228576.

Cf. A137948, A245334.

Cf. A085478, A258993.

KEYWORD	
nonn,tabl,nice,easy,core,look,hear,changed

AUTHOR	
N. J. A. Sloane and Mira Bernstein, Apr 28 1994

EXTENSIONS	
Checked all links, deleted 8 that seemed lost forever and were probably not of great importance. - N. J. A. Sloane, May 08 2018

STATUS	
approved