fn is_divisible_by(divisor: u32, n: u32) -> bool {
    n % divisor == 0
}

pub fn raindrops(n: u32) -> String {
    let mut output = "".to_owned();
    if is_divisible_by(3, n) {
        output += "Pling";
    }

    if is_divisible_by(5, n) {
        output += "Plang";
    }

    if is_divisible_by(7, n) {
        output += "Plong";
    }

    if output.is_empty() {
        n.to_string()
    } else {
        output
    }
}
