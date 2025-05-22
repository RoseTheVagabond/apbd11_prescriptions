-- test 1 for POST - prescription added for an existing patient
{
  "patient": {
    "idPatient": 1,
    "firstName": "Jane",
    "lastName": "Doe",
    "birthDate": "1990-05-15T00:00:00"
  },
  "doctor": {
    "idDoctor": 1
  },
  "date": "2024-05-22T10:00:00",
  "dueDate": "2024-05-29T10:00:00",
  "medicamentsDto": [
    {
      "idMedicament": 1,
      "name": "Aspirin",
      "description": "Take with food",
      "dose": 2
    },
    {
      "idMedicament": 3,
      "name": "Paracetamol", 
      "description": "As needed for pain",
      "dose": 1
    }
  ]
}

-- test 2 for POST - prescription added for a new patient
{
  "patient": {
    "idPatient": 0,
    "firstName": "Alice",
    "lastName": "Cooper",
    "birthDate": "1985-03-20T00:00:00"
  },
  "doctor": {
    "idDoctor": 2
  },
  "date": "2024-05-22T14:00:00",
  "dueDate": "2024-06-05T14:00:00",
  "medicamentsDto": [
    {
      "idMedicament": 5,
      "name": "Lisinopril",
      "description": "Take daily with breakfast",
      "dose": 1
    }
  ]
}

-- test 3 for POST - over 10 medicaments
{
  "patient": {
    "idPatient": 1,
    "firstName": "Jane",
    "lastName": "Doe",
    "birthDate": "1990-05-15T00:00:00"
  },
  "doctor": {
    "idDoctor": 1
  },
  "date": "2024-05-22T10:00:00",
  "dueDate": "2024-05-29T10:00:00",
  "medicamentsDto": [
    {"idMedicament": 1, "name": "Aspirin", "description": "Med 1", "dose": 1},
    {"idMedicament": 2, "name": "Ibuprofen", "description": "Med 2", "dose": 1},
    {"idMedicament": 3, "name": "Paracetamol", "description": "Med 3", "dose": 1},
    {"idMedicament": 4, "name": "Amoxicillin", "description": "Med 4", "dose": 1},
    {"idMedicament": 5, "name": "Lisinopril", "description": "Med 5", "dose": 1},
    {"idMedicament": 6, "name": "Metformin", "description": "Med 6", "dose": 1},
    {"idMedicament": 7, "name": "Omeprazole", "description": "Med 7", "dose": 1},
    {"idMedicament": 8, "name": "Simvastatin", "description": "Med 8", "dose": 1},
    {"idMedicament": 9, "name": "Albuterol", "description": "Med 9", "dose": 1},
    {"idMedicament": 10, "name": "Warfarin", "description": "Med 10", "dose": 1},
    {"idMedicament": 1, "name": "Aspirin", "description": "Med 11", "dose": 1}
  ]
}

-- test 4 for POST - dates set up wrongly
{
  "patient": {
    "idPatient": 1,
    "firstName": "Jane",
    "lastName": "Doe",
    "birthDate": "1990-05-15T00:00:00"
  },
  "doctor": {
    "idDoctor": 1
  },
  "date": "2024-05-22T10:00:00",
  "dueDate": "2024-05-15T10:00:00",
  "medicamentsDto": [
    {
      "idMedicament": 1,
      "name": "Aspirin",
      "description": "Test",
      "dose": 1
    }
  ]
}

-- test 5 for POST - doctor with the given id doesn't exist
{
  "patient": {
    "idPatient": 1,
    "firstName": "Jane",
    "lastName": "Doe",
    "birthDate": "1990-05-15T00:00:00"
  },
  "doctor": {
    "idDoctor": 999
  },
  "date": "2024-05-22T10:00:00",
  "dueDate": "2024-05-29T10:00:00",
  "medicamentsDto": [
    {
      "idMedicament": 1,
      "name": "Aspirin",
      "description": "Test",
      "dose": 1
    }
  ]
}

-- test 6 for POST - medication doesn't exist
{
  "patient": {
    "idPatient": 1,
    "firstName": "Jane",
    "lastName": "Doe",
    "birthDate": "1990-05-15T00:00:00"
  },
  "doctor": {
    "idDoctor": 1
  },
  "date": "2024-05-22T10:00:00",
  "dueDate": "2024-05-29T10:00:00",
  "medicamentsDto": [
    {
      "idMedicament": 999,
      "name": "NonExistent",
      "description": "Test",
      "dose": 1
    }
  ]
}
