use std::iter::successors;

pub fn egg_count(display_value: u32) -> usize {
    successors(Some(display_value), |&prev| {
        if prev > 1 { Some(prev / 2) } else { None }
    })
    .filter(|n| n % 2 == 1)
    .count()
}
