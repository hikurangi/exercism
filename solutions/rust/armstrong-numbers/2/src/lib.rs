pub fn is_armstrong_number(num: u32) -> bool {
    let stringified = num.to_string();
    let count: u32 = stringified.len().try_into().unwrap();

    num as u64
        == stringified
            .chars()
            .map(|n| (n.to_digit(10).unwrap() as u64).pow(count))
            .sum()
}

// pub fn is_armstrong_number(num: u32) -> bool {
//     let mut q = num as u64;
//     let mut digits = Vec::new();
//     while q > 0 {
//         digits.push(q % 10);
//         q /= 10;
//     }

//     let count = digits.len() as u32;
//     digits.iter().map(|d| d.pow(count)).sum::<u64>() == (num as u64)
// }

// pub fn is_armstrong_number(num: u32) -> bool {
//     if num == 0 {
//         return true;
//     }
//     let capacity: u32 = num.ilog10() + 1;
//     (0..capacity)
//         .map(|index| ((num / 10_u32.pow(index)) % 10).pow(capacity))
//         .try_fold(0_u32, |init, value| init.checked_add(value))
//         .is_some_and(|sum| sum == num)
// }

// pub fn is_armstrong_number(num: u64) -> bool {
//     let num_len = num.to_string().len() as u32;

//     num == num
//         .to_string()
//         .chars()
//         .fold(0, |t, x| (x.to_digit(10).unwrap() as u64).pow(num_len) + t)
// }
