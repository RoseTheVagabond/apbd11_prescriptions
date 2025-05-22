INSERT INTO Doctors (FirstName, LastName, Email) VALUES
                                                     ('John', 'Smith', 'john.smith@hospital.com'),
                                                     ('Sarah', 'Johnson', 'sarah.johnson@clinic.com'),
                                                     ('Michael', 'Brown', 'michael.brown@medical.com'),
                                                     ('Emily', 'Davis', 'emily.davis@healthcare.com'),
                                                     ('David', 'Wilson', 'david.wilson@hospital.com');

INSERT INTO Medicaments (Name, Description, Type) VALUES
                                                      ('Aspirin', 'Pain reliever and fever reducer', 'Tablet'),
                                                      ('Ibuprofen', 'Anti-inflammatory pain reliever', 'Capsule'),
                                                      ('Paracetamol', 'Pain reliever and fever reducer', 'Tablet'),
                                                      ('Amoxicillin', 'Antibiotic for bacterial infections', 'Capsule'),
                                                      ('Lisinopril', 'ACE inhibitor for high blood pressure', 'Tablet'),
                                                      ('Metformin', 'Diabetes medication', 'Tablet'),
                                                      ('Omeprazole', 'Proton pump inhibitor for acid reflux', 'Capsule'),
                                                      ('Simvastatin', 'Cholesterol-lowering medication', 'Tablet'),
                                                      ('Albuterol', 'Bronchodilator for asthma', 'Inhaler'),
                                                      ('Warfarin', 'Blood thinner', 'Tablet');

INSERT INTO Patients (FirstName, LastName, BirthDate) VALUES
                                                          ('Jane', 'Doe', '1990-05-15'),
                                                          ('Robert', 'Miller', '1985-08-22'),
                                                          ('Lisa', 'Anderson', '1992-03-10'),
                                                          ('Mark', 'Taylor', '1978-11-05'),
                                                          ('Jennifer', 'White', '1995-07-18'),
                                                          ('Christopher', 'Harris', '1982-12-30'),
                                                          ('Amanda', 'Martin', '1988-04-25'),
                                                          ('Daniel', 'Thompson', '1991-09-12');

INSERT INTO Prescriptions (Date, DueDate, IdPatient, IdDoctor) VALUES
                                                                   ('2024-01-15', '2024-01-22', 1, 1),  -- Jane Doe prescribed by John Smith
                                                                   ('2024-01-16', '2024-01-30', 2, 2),  -- Robert Miller prescribed by Sarah Johnson
                                                                   ('2024-01-17', '2024-01-24', 3, 1),  -- Lisa Anderson prescribed by John Smith
                                                                   ('2024-01-18', '2024-02-01', 1, 3),  -- Jane Doe prescribed by Michael Brown
                                                                   ('2024-01-19', '2024-01-26', 4, 2),  -- Mark Taylor prescribed by Sarah Johnson
                                                                   ('2024-01-20', '2024-02-03', 5, 4),  -- Jennifer White prescribed by Emily Davis
                                                                   ('2024-01-21', '2024-01-28', 2, 1);  -- Robert Miller prescribed by John Smith

INSERT INTO PrescriptionMedicaments (IdPrescription, IdMedicament, Dose, Details) VALUES
(1, 1, 2, 'Take 2 tablets twice daily with food'),
(1, 2, 1, 'Take 1 capsule as needed for pain'),
(2, 4, 3, 'Take 3 capsules daily for 7 days'),
(2, 3, 2, 'Take 2 tablets every 6 hours for fever'),
(3, 5, 1, 'Take 1 tablet daily in the morning'),
(4, 6, 2, 'Take 2 tablets with breakfast'),
(4, 8, 1, 'Take 1 tablet at bedtime'),
(5, 7, 1, 'Take 1 capsule before breakfast'),
(5, 1, 1, 'Take 1 tablet daily for heart protection'),
(6, 9, 2, 'Use 2 puffs as needed for breathing difficulty'),
(7, 10, 1, 'Take 1 tablet daily, monitor INR levels');