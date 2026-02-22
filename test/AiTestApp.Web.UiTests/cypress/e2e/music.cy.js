describe('Music UI Tests', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('should navigate to Albums from the home page', () => {
    cy.get('a.btn-success').contains('Give me an Album!').click();
    cy.url().should('include', '/Music/AlbumPrompt');
    cy.get('h1').should('contain', 'Select a Genre');
  });

  it('should navigate to Albums from the navbar', () => {
    cy.get('.navbar-nav .nav-link').contains('Albums').click();
    cy.url().should('include', '/Music/AlbumPrompt');
    cy.get('h1').should('contain', 'Select a Genre');
  });

  it('navigates to Album Prompt, selects a genre, and picks a random album', () => {
    cy.visit('/Music/AlbumPrompt');
    cy.get('.btn').contains('Rock').click();
    cy.url().should('include', '/Music?genre=Rock');
    cy.get('h1').should('be.visible');

    cy.get('h1').then(($title1) => {
        const firstTitle = $title1.text();
        cy.get('.btn').contains(/Pick Another .* Album/).click();
        cy.get('h1').should(($title2) => {
            expect($title2.text()).to.not.equal(firstTitle);
        });
    });

    cy.get('.btn').contains('Select Different Genre').click();
    cy.url().should('include', '/Music/AlbumPrompt');
  });

  it('picks a completely random album', () => {
    cy.visit('/Music/AlbumPrompt');
    cy.get('.btn').contains('Pick One at Random').click();
    cy.url().should('include', '/Music');
    cy.get('h1').should('be.visible');
  });
});
