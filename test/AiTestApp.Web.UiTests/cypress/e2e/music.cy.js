describe('Music UI Tests', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('navigates to Albums page, selects a genre, and picks a random album', () => {
    cy.get('nav .nav-link').contains('Albums').click();
    cy.url().should('include', '/Music/AlbumPrompt');
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
    cy.get('nav .nav-link').contains('Albums').click();
    cy.url().should('include', '/Music/AlbumPrompt');
    cy.get('.btn').contains('Pick One at Random').click();
    cy.url().should('include', '/Music');
    cy.get('h1').should('be.visible');
  });
});
