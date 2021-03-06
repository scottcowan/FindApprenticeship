$(function() {
  var frameworks =  [
    // "Agriculture, Horticulture and Animal Care",
    "Agriculture",
    "Animal Care",
    "Animal Technology",
    "Animal Technology",
    "Environmental Conservation",
    "Equine",
    "Farriery",
    "Fencing",
    "Fish Husbandry and Fisheries Management",
    "Floristry",
    "Game and Wildlife Management",
    "Horticulture",
    "Landbased Engineering",
    "Nursing Assistants in a Veterinary Environment",
    "Trees and Timber",
    "Veterinary Nursing",
    // "Arts, Media and Publishing",
    "Advertising & Marketing Communications",
    "Automative Clay Modelling",
    "Broadcast Production",
    "Broadcasting Technology",
    "Community Arts",
    "Costume and Wardrobe",
    "Craft and Technical Roles in Film and Television",
    "Creative and Digital Media",
    "Creative Craft Practitioner",
    "Cultural and Heritage Venue operations",
    "Design",
    "Digital Learning Design",
    "Interactive Design and Development",
    "Journalism",
    "Live Events and Promotion",
    "Music Business",
    "Photo Imaging",
    "SetCrafts",
    "Sound Recording",
    "Engineering and Studio Facilities",
    "Technical Theatre",
    // "Business, Administration and Law",
    "Accounting",
    "Banking",
    "Bookkeeping",
    "Business and Administration ",
    "Business Innovation and Growth",
    "Campaigning",
    "Contact Centre Operations",
    "Criminal Investigation",
    "Customer Service",
    "Enterprise",
    "Fundraising",
    "Human Resource Management",
    "Insurance",
    "Legal Advice",
    "Legal Services",
    "Management",
    "Marketing",
    "Payroll",
    "Professional Services",
    "Project Management",
    "Providing Financial Advice",
    "Providing Financial Services",
    "Providing Mortgage Advice",
    "Public Relations",
    "Management",
    "Sales and Telesales",
    "Social Media and Digital Marketing",
    "Trade Business",
    "Volunteer Management",
    // "Construction, Planning and the Built Environment",
    "Building Energy Management Systems",
    "Building Services Engineering Technology",
    "Construction Building",
    "Construction Civil Engineering",
    "Construction Management",
    "Construction Specialist",
    "Construction Technical",
    "Domestic Heating",
    "Heating and Ventilation",
    "Plumbing and Heating",
    "Refrigeration and Air Conditioning",
    "Surveying",
    // "Education and Training",
    "Learning and Development",
    "Learning Support",
    "Supporting Teaching and Learning in Physical Education",
    "Supporting Teaching and Learning in Schools",
    // "Engineering and Manufacturing Technologies",
    "Advanced Diagnostics and Management Principles",
    "Advanced Engineering Construction",
    "Advanced Manufacturing Engineering",
    "Automotive Management and Leadership",
    "Aviation Operations on the Ground",
    "Blacksmithing",
    "Building Products Industry Occupations",
    "Bus and Coach Engineering and Maintenance",
    "Ceramics Manufacturing",
    "Combined Manufacturing Processes",
    "Composite Engineering",
    "Consumer Electrical and Electronic Products",
    "Driving Goods Vehicles",
    "Electrotechnical",
    "Engineering Construction – ECITB",
    "Engineering Environmental Technologies",
    "Engineering Manufacture",
    "Engineering Manufacture",
    "Explosives",
    "Storage & Maintenance",
    "Extractives",
    "Fashion and Textiles:Technical",
    "Food and Drink",
    "Furniture",
    "Furnishing and Interiors",
    "Glass Industry",
    "Improving Operational Performance",
    "Jewellery",
    "Silversmithing and Allied Trades",
    "Laboratory and Science Technicians",
    "Marine Industry",
    "Maritime Occupations",
    "Metal Processing and Allied Operations",
    "Mineral Products Technology",
    "Multi-Skilled Vehicle Collision Repair",
    "Nuclear Working",
    "Operations and Quality Improvement",
    "Passenger Carrying Vehicle Driving",
    "Polymer Processing Operations",
    "Power Engineering",
    "Print and Printed Packaging",
    "Process Manufacturing",
    "Production of Coatings",
    "Professional Aviation Pilot Practice",
    "Rail Engineering",
    "Rail Engineering Overhead Line Construction",
    "Rail Infrastructure Engineering",
    "Rail Services",
    "Rail Traction and Rolling Stock Engineering",
    "Sea Fishing",
    "Signmaking",
    "Smart Meter Installations",
    "Sustainable Resource Management",
    "The Gas Industry",
    "The Power Industry",
    "The Water Industry",
    "Vehicle Body and Paint",
    "Vehicle Fitting",
    "Vehicle Maintenance and Repair",
    "Vehicle Parts",
    "Wood & Timber Processing and Merchants Industry",
    // "Health, Public Services and Care",
    "Care Leadership and Management",
    "Children and Young People's Workforce",
    "Courts",
    "Tribunal and Prosecution Administration",
    "Custodial Care",
    "Emergency Fire Service Operations",
    "Employment Related Services",
    "Health  - Allied Health Profession Support",
    "Health - Blood Donor Support",
    "Health - Clinical Healthcare",
    "Health - Dental Nursing",
    "Health - Emergency Care",
    "Health - Healthcare Support Services",
    "Health - Maternity and Paediatric Support",
    "Health - Optical Retail",
    "Health - Pathology Support",
    "Health - Perioperative Support",
    "Health - Pharmacy Services",
    "Health Informatiion",
    "Health and Social Care",
    "Health Assistant Practitioner",
    "HM Forces",
    "Housing",
    "Intelligence Analysis",
    "Libraries Records and IM Services",
    "Local Taxation and Benefits",
    "Locksmithing",
    "Policing",
    "Professional Development for Work Based Learning Practitioners",
    "Providing Security Services",
    "Security Systems",
    "Witness Care",
    "Youth Work",
    // "Information and Communication Technology",
    "Information Security",
    "IT Application Specialist",
    "IT",
    "Software",
    "Web & Telecoms Professionals",
    // "Leisure, Travel and Tourism",
    "Activity Leadership",
    "Advanced Playwork",
    "Advanced Spectator Safety",
    "Cabin Crew",
    "Coaching",
    "Exercise and Fitness",
    "Leisure Management",
    "Leisure Operations",
    "Outdoor Programmes",
    "Playwork",
    "Spectator Safety",
    "Sporting Excellence",
    "Sports Development",
    "Travel Services",
    // "Retail and Commercial Enterprise",
    "Barbering",
    "Beauty Therapy",
    "Catering and Professional Chefs",
    "Cleaning and Environmental Services",
    "Commercial Moving",
    "Drinks Dispense Systems",
    "Energy Assessment and Advice",
    "Express Logistics",
    "Facilities Management",
    "Fashion and Textiles",
    "Funeral Operations and Services",
    "Hairdressing",
    "Hospitality",
    "Hospitality Management",
    "International Supply Chain Management",
    "International Trade and Logistics",
    "Licensed Hospitality",
    "Logistics Operations",
    "Mail Services and Package Distribution",
    "Nail Services",
    "Procurement",
    "Property Services",
    "Purchasing and  Supply Management",
    "Retail",
    "Retail Management",
    "Spa Therapy",
    "Supply Chain Management",
    "Traffic Office",
    "Vehicle Sales",
    "Warehousing and Storage",
    // "Science and Mathematics",
    "Life Sciences"
  ];


  $( "#choose-framework" ).autocomplete({
      source: frameworks
    });
});

