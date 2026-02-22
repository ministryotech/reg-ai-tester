describe('Generator Pages', () => {
  beforeEach(() => {
    cy.visit('http://localhost:5104');
  });

  it('navigates to TV Shows page and picks a random show', () => {
    cy.get('nav .nav-link').contains('TV Shows').click();
    cy.url().should('include', '/Generator/TvShow');
    cy.get('h1').should('be.visible');
    cy.get('p').contains('Genre:').should('be.visible');

    cy.get('h1').then(($title1) => {
        const firstTitle = $title1.text();
        cy.get('.btn').contains('Pick Another Random TV Show').click();
        cy.get('h1').should(($title2) => {
            expect($title2.text()).to.not.equal(firstTitle);
        });
    });
  });

  it('navigates to Books page, selects a genre, and picks a random book', () => {
    cy.get('nav .nav-link').contains('Books').click();
    cy.url().should('include', '/Generator/BookGenre');
    cy.get('.btn').contains('Science Fiction').click();
    cy.url().should('include', '/Generator/Book?genre=Science%20Fiction');
    cy.get('h1').should('be.visible');

    cy.get('h1').then(($title1) => {
        const firstTitle = $title1.text();
        cy.get('.btn').contains('Pick Another Science Fiction Book').click();
        cy.get('h1').should(($title2) => {
            expect($title2.text()).to.not.equal(firstTitle);
        });
    });

    cy.get('.btn').contains('Change Genre').click();
    cy.url().should('include', '/Generator/BookGenre');
  });

  it('navigates to Albums page, selects a genre, and picks a random album', () => {
    cy.get('nav .nav-link').contains('Albums').click();
    cy.url().should('include', '/Generator/AlbumPrompt');
    cy.get('.btn').contains('Rock').click();
    cy.url().should('include', '/Generator/Album?genre=Rock');
    cy.get('h1').should('be.visible');

    cy.get('h1').then(($title1) => {
        const firstTitle = $title1.text();
        cy.get('.btn').contains(/Pick Another .* Album/).click();
        cy.get('h1').should(($title2) => {
            expect($title2.text()).to.not.equal(firstTitle);
        });
    });

    cy.get('.btn').contains('Select Different Genre').click();
    cy.url().should('include', '/Generator/AlbumPrompt');
  });

  it('picks a completely random album', () => {
    cy.get('nav .nav-link').contains('Albums').click();
    cy.url().should('include', '/Generator/AlbumPrompt');
    cy.get('.btn').contains('Pick One at Random').click();
    cy.url().should('include', '/Generator/Album');
    cy.get('h1').should('be.visible');
  });

  it('navigates to Dice page, selects a die, and rolls it', () => {
    cy.get('nav .nav-link').contains('Dice').click();
    cy.url().should('include', '/Generator/Dice');
    cy.get('.btn').contains('d20').click();
    cy.url().should('include', '/Generator/Roll?dieType=d20');
    cy.get('.display-1').should('be.visible').and(($el) => {
        const val = parseInt($el.text());
        expect(val).to.be.at.least(1).and.at.most(20);
    });
    cy.get('.btn').contains('Roll Again').click();
    cy.get('.btn').contains('Select Different Die').click();
    cy.url().should('include', '/Generator/Dice');
  });
});
