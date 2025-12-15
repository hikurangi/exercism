use std::collections::HashSet;

#[derive(Debug, Clone)]
struct Student {
    name: String,
    grade: u32,
}

pub struct School {
    students: Vec<Student>,
}

impl School {
    pub fn new() -> Self {
        Self {
            students: Vec::new(),
        }
    }

    pub fn add(&mut self, grade: u32, student: &str) {
        if !self.students.iter().any(|s| s.name == student) {
            self.students.push(Student {
                name: student.to_string(),
                grade,
            });
        }
    }

    pub fn grades(&self) -> Vec<u32> {
        let mut grades: Vec<u32> = self
            .students
            .iter()
            .map(|student| student.grade)
            .collect::<HashSet<_>>()
            .into_iter()
            .collect();

        grades.sort_unstable();
        grades
    }

    pub fn grade(&self, grade: u32) -> Vec<String> {
        let mut grade: Vec<String> = self
            .students
            .iter()
            .filter(|s| s.grade == grade)
            .map(|s| s.name.to_string())
            .collect();

        grade.sort_unstable();
        grade
    }
}
