use std::collections::HashSet;

pub fn sum_of_multiples(limit: u32, factors: &[u32]) -> u32 {
    factors
        .iter()
        .flat_map(|f| (1..).take_while(move |n| n * f < limit).map(move |n| n * f))
        .fold(HashSet::new(), |mut seen, multiple| {
            seen.insert(multiple);
            seen
        })
        .into_iter()
        .sum()
}
